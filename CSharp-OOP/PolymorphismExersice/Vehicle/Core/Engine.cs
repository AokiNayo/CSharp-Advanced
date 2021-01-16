﻿using System;
using Vehicles.Models;
using Vehicles.Core.Contracts;
using Vehicles.Factories;

namespace Vehicles.Core
{
    public class Engine : IEngine
    {
        private readonly VehicleFactory vehicleFactory;

        public Engine()
        {
            this.vehicleFactory = new VehicleFactory();
        }
        public void Run()
        {
            Vehicle car = this.ProcessVehicleInfo();
            Vehicle truck = this.ProcessVehicleInfo();
            Vehicle bus = this.ProcessVehicleInfo();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string cmdType = cmdArgs[0];
                string vehicleType = cmdArgs[1];
                double args = double.Parse(cmdArgs[2]);

                try
                {
                    if (cmdType == "Drive")
                    {
                        if (vehicleType == "Car")
                        {
                            this.Drive(car, args);
                        }
                        else if (vehicleType == "Truck")
                        {
                            this.Drive(truck, args);
                        }
                        else if (vehicleType == "Bus")
                        {
                            this.Drive(bus, args);
                        }
                    }
                    else if (cmdType == "DriveEmpty")
                    {
                        this.DriveEmpty(bus, args);
                    }
                    else if (cmdType == "Refuel")
                    {
                        if (vehicleType == "Car")
                        {
                            this.Refuel(car, args);
                        }
                        else if (vehicleType == "Truck")
                        {
                            this.Refuel(truck, args);
                        }
                        else if (vehicleType == "Bus")
                        {
                            this.Refuel(bus, args);
                        }
                    }
                }
                catch (InvalidOperationException msg)
                {
                    Console.WriteLine(msg.Message);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
        private void Refuel(Vehicle vehicle, double fuelAmount)
        {
            vehicle.Refuel(fuelAmount);
        }
        private void Drive(Vehicle vehicle, double kilometers)
        {
            Console.WriteLine(vehicle.Drive(kilometers));
        }
        private void DriveEmpty(Vehicle vehicle, double kilometers)
        {
            Console.WriteLine(vehicle.DriveEmpty(kilometers));
        }
        private Vehicle ProcessVehicleInfo()
        {
            string[] vehicleArgs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string vehicleType = vehicleArgs[0];
            double fuelQuantity = double.Parse(vehicleArgs[1]);
            double fuelConsumption = double.Parse(vehicleArgs[2]);
            double tankCapacity = double.Parse(vehicleArgs[3]);

            Vehicle currentVehicle = this.vehicleFactory.CreateVehicle(vehicleType, fuelQuantity, fuelConsumption, tankCapacity);

            return currentVehicle;

        }
    }
}
