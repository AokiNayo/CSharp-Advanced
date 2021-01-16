using System;
using NUnit.Framework;

namespace Tests
{
    public class CarTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("VW", "Golf3", 10, 100)]
        [TestCase("BMW", "3", 20, 100)]
        public void CarConstructorShouldSetDataCorrectly(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.AreEqual(car.Make, make);
            Assert.AreEqual(car.Model, model);
            Assert.AreEqual(car.FuelConsumption, fuelConsumption);
            Assert.AreEqual(car.FuelCapacity, fuelCapacity);
            Assert.AreEqual(car.FuelAmount, 0);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void CarPropertyMakeIsNullOrEmpty(string make)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, "Golf", 200, 1000));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void CarPropertyModelIsNullOrEmpty(string model)
        {
            Assert.Throws<ArgumentException>(() => new Car("VW", model, 200, 1000));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-200)]
        public void CarPropertyFuelConsumptionIsNullOrEmpty(double fuelConsumption)
        {
            Assert.Throws<ArgumentException>(() => new Car("VW", "Golf", fuelConsumption, 1000));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-200)]
        public void CarPropertyFuelCapacityIsNullOrEmpty(double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car("VW", "Golf", 100, fuelCapacity));
        }

        [Test]
        [TestCase("VW", "Golf3", 10, 100, 200)]
        [TestCase("VW", "Golf3", 10, 100, 100)]
        public void CarRefuelAmountShouldNotBeAboveFuelCapacity(string make, string model, double fuelConsumption, double fuelCapacity, int refuelAmount)
        {
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            car.Refuel(refuelAmount);

            Assert.AreEqual(fuelCapacity, car.FuelAmount);
        }

        [Test]
        [TestCase("VW", "Golf3", 10, 100, -1)]
        [TestCase("VW", "Golf3", 10, 100, 0)]
        public void CarRefuelAmountBelowOrEqualToZeroThrowsArgumentException(string make, string model, double fuelConsumption,
            double fuelCapacity, int refuelAmount)
        {
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.Throws<ArgumentException>(() => car.Refuel(refuelAmount));
        }

        [Test]
        [TestCase("VW", "Golf3", 10, 100, 50)]
        public void CorrectRefuelAmount(string make, string model, double fuelConsumption,
            double fuelCapacity, int refuelAmount)
        {
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            car.Refuel(refuelAmount);

            Assert.AreEqual(50, car.FuelAmount);
        }

        [Test]
        [TestCase("VW", "Golf3", 10, 1000, 200, 50)]
        public void DriveCarIfEnoughFuelAmount(string make, string model, double fuelConsumption,
            double fuelCapacity, int refuelAmount, double distance)
        {
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            car.Refuel(refuelAmount);
            car.Drive(distance);

            var fuelNeeded = distance / 100 * car.FuelConsumption;

            var expectedValue = refuelAmount - fuelNeeded;
            var actualValue = car.FuelAmount;

            Assert.AreEqual(expectedValue, actualValue);

        }

        [Test]
        [TestCase("VW", "Golf3", 10, 1000, 200)]
        public void CarThrowsExceptionIfNotEnoughFuelAmount(string make, string model, double fuelConsumption,
            double fuelCapacity, double distance)
        {
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.Throws<InvalidOperationException>((() => car.Drive(distance)));


        }

    }
}