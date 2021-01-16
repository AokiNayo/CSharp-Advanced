using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double FUEL_CONS_INCR = 1.6;
        private const double FUEL_LEAK = 0.05;
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }

        public override double FuelConsumption =>
            base.FuelConsumption + FUEL_CONS_INCR;

        public override string DriveEmpty(double kmAmount)
        {
            throw new NotImplementedException();
        }

        public override void Refuel(double fuelAmount)
        {
            base.Refuel(fuelAmount);
            this.FuelQuantity -= (fuelAmount * FUEL_LEAK);
        }
    }
}
