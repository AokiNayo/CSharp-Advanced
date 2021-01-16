using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        protected double fuelQuantity;
        protected double fuelConsumption;

        public Vehicle(double fuelQuantity, double litersPerKM)
        {
            this.fuelQuantity = fuelQuantity;
            this.fuelConsumption = litersPerKM;
        }

        public abstract void Drive(double distance);
        public abstract void Refuel(double liters);
    }
}
