﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        const double increasedConsumption = 1.6;
        const double fuelLeak = 0.95;
        public Truck(double fuelQuantity, double litersPerKM)
            : base(fuelQuantity, litersPerKM)
        {
        }

        public override void Drive(double distance)
        {
            var result = fuelConsumption * distance + increasedConsumption * distance;

            if (result > this.fuelQuantity)
            {
                Console.WriteLine($"{typeof(Truck).Name} needs refueling");
                return;
            }

            this.fuelQuantity -= result;
            Console.WriteLine($"{typeof(Truck).Name} travelled {distance} km");
        }

        public override void Refuel(double liters)
        {
            this.fuelQuantity += liters * fuelLeak;
        }

        public override string ToString()
        {
            return $"Truck: {fuelQuantity:f2}";
        }
    }
}
