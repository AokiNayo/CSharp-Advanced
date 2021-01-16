using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Common;

namespace Vehicles.Models
{
    public class Bus : Vehicle
    {
        private const double FUEL_CONS_INCR = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }
        public override string Drive(double kmAmount)
        {
            double fuelNeeded = kmAmount * (this.FuelConsumption + FUEL_CONS_INCR);

            if (this.FuelQuantity < fuelNeeded)
            {
                throw new InvalidOperationException(String.Format
                    (ExceptionMessages.NOT_ENOUGH_FUEL_MSG, GetType().Name));
            }

            this.FuelQuantity -= fuelNeeded;

            return String.Format(SUCC_DRIVED_MSG, this.GetType().Name, kmAmount);
        }
        public override string DriveEmpty(double kmAmount)
        {
            double fuelNeeded = kmAmount * this.FuelConsumption;

            if (this.FuelQuantity < fuelNeeded)
            {
                throw new InvalidOperationException(String.Format
                    (ExceptionMessages.NOT_ENOUGH_FUEL_MSG, GetType().Name));
            }

            this.FuelQuantity -= fuelNeeded;
            return String.Format(SUCC_DRIVED_MSG, this.GetType().Name, kmAmount);
        }
    }
}
