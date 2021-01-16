using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        const double increasedConsumption = 0.9;
        public Car(double fuelQuantity, double litersPerKM, double tankCapacity)
            : base(fuelQuantity, litersPerKM, tankCapacity)
        {
        }

        public override void Drive(double distance)
        {
            var result = fuelConsumption * distance + increasedConsumption * distance;

            if (result > this.fuelQuantity)
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
                return;
            }

            this.fuelQuantity -= result;
            Console.WriteLine($"{this.GetType().Name} travelled {distance} km");

        }
        public override string ToString()
        {
            return $"Car: {fuelQuantity:f2}";
        }
    }
}
