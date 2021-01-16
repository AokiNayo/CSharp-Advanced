using System;
using System.Collections.Generic;
using System.Text;
using Vehicles;

namespace VehiclesExtension
{
    public class Bus : Vehicle
    {
        private const double increasedConsumption = 1.4;
        public Bus(double fuelQuantity, double litersPerKM, double tankCapacity) 
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
        public void DriveEmpty(double distance)
        {
            var result = fuelConsumption * distance;

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
            return $"Bus: {fuelQuantity:f2}";
        }
    }
}
