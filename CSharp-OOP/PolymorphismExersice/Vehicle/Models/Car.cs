using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double FUEL_CONS_INCR = 0.9;
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }

        public override double FuelConsumption =>
            base.FuelConsumption + FUEL_CONS_INCR;

        public override string DriveEmpty(double kmAmount)
        {
            throw new NotImplementedException();
        }
    }
}
