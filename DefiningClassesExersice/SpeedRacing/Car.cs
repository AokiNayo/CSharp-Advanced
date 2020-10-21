using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    class Car
    {
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }

        public Car()
        {
            TravelledDistance = 0;
        }

        public Car(string model, double fuelAmount, double fuelConsumption) : this()
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumption;
        }

        public void Drive(double amountOfKm)
        {
            if (amountOfKm * FuelConsumptionPerKilometer > FuelAmount)
            {
                Console.WriteLine("Insufficient fuel for the drive");
                return;
            }

            FuelAmount -= amountOfKm * FuelConsumptionPerKilometer;
            TravelledDistance += amountOfKm;
        }
    }
}
