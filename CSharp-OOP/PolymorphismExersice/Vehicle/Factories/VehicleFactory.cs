using System;
using Vehicles.Common;
using Vehicles.Models;

namespace Vehicles.Factories
{
    public class VehicleFactory
    {
        public VehicleFactory()
        {

        }
        // Не используется так, но мы не знаем "Reflection" 
        public Vehicle CreateVehicle(string vehicleType, double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            Vehicle vehicle;
            if (vehicleType == "Car")
            {
                vehicle = new Car(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else if (vehicleType == "Truck")
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else if (vehicleType == "Bus")
            {
                vehicle = new Bus(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.INV_VEHICLE_TYPE);
            }
            return vehicle;
        }
    }
}
