using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Common;
using Vehicles.Models.Contracts;

namespace Vehicles.Models
{
    public abstract class Vehicle : IDriveable, IRefuelable
    {
        protected const string SUCC_DRIVED_MSG = "{0} travelled {1} km";

        private double fuelQuantity;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }
        public double FuelQuantity
        {
            get => this.fuelQuantity;
            protected set
            {
                if (value > this.TankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }

        public virtual double FuelConsumption { get; }

        public double TankCapacity { get; private set; }
        

        public virtual string Drive(double kmAmount)
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

        public abstract string DriveEmpty(double kmAmount);
        

        public virtual void Refuel(double fuelAmount)
        {
            if (fuelAmount <= 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NEG_FUEL_MSG);
            }
            if (fuelAmount + FuelQuantity > TankCapacity)
            {
                throw new InvalidOperationException(String.Format
                    (ExceptionMessages.OVR_FUEL_MSG, fuelAmount));
            }
            this.FuelQuantity += fuelAmount;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {FuelQuantity:f2}";
        }
    }
}
