using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        const double increasedConsumption = 0.9;
        public Car(double fuelQuantity, double litersPerKM)
            : base(fuelQuantity, litersPerKM)
        {
        }

        public override void Drive(double distance)
        {
            var result = fuelConsumption * distance + increasedConsumption * distance;

            if (result > this.fuelQuantity)
            {
                Console.WriteLine($"{typeof(Car).Name} needs refueling");
                return;
            }

            this.fuelQuantity -= result;
            Console.WriteLine($"{typeof(Car).Name} travelled {distance} km");

        }

        public override void Refuel(double liters)
        {
            this.fuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"Car: {fuelQuantity:f2}";
        }
    }
}
