using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        protected double fuelQuantity;
        protected double fuelConsumption;
        protected double tankCapacity;

        public Vehicle(double fuelQuantity, double litersPerKM, double tankCapacity)
        {
            this.fuelQuantity = fuelQuantity;
            this.fuelConsumption = litersPerKM;
            this.tankCapacity = tankCapacity;
        }
        public double FuelQuantity
        {
            get => this.fuelQuantity;
            protected set
            {
                if (value > this.tankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }
        public abstract void Drive(double distance);

        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
                return;
            }
            if (tankCapacity < fuelQuantity + liters)
            {
                Console.WriteLine($"Cannot fit {liters} fuel in the tank");
                return;
            }
            fuelQuantity += liters;
        }
    }
}
