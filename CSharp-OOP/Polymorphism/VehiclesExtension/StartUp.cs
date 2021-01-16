using System;
using Vehicles;

namespace VehiclesExtension
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var carArgs = Console.ReadLine().Split();
            var truckArgs = Console.ReadLine().Split();
            var busArgs = Console.ReadLine().Split();

            Vehicle car = new Car(double.Parse(carArgs[1]), double.Parse(carArgs[2]), double.Parse(carArgs[3]));
            Vehicle truck = new Truck(double.Parse(truckArgs[1]), double.Parse(truckArgs[2]), double.Parse(carArgs[3]));
            Vehicle bus = new Bus(double.Parse(busArgs[1]), double.Parse(busArgs[2]), double.Parse(busArgs[3]));


            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var cmdArgs = Console.ReadLine().Split();

                if (cmdArgs[0] == "Drive")
                {
                    if (cmdArgs[1] == "Car")
                    {
                        car.Drive(double.Parse(cmdArgs[2]));
                    }
                    else if (cmdArgs[1] == "Truck")
                    {
                        truck.Drive(double.Parse(cmdArgs[2]));
                    }
                    else
                    {
                        bus.Drive(double.Parse(cmdArgs[2]));
                    }
                }
                else if (cmdArgs[0] == "DriveEmpty")
                {
                    ((Bus)bus).DriveEmpty(double.Parse(cmdArgs[2]));
                }
                else
                {
                    if (cmdArgs[1] == "Car")
                    {
                        car.Refuel(double.Parse(cmdArgs[2]));
                    }
                    else if (cmdArgs[1] == "Truck")
                    {
                        truck.Refuel(double.Parse(cmdArgs[2]));

                    }
                    else
                    {
                        bus.Refuel(double.Parse(cmdArgs[2]));
                    }
                }
            }
            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
            Console.WriteLine(bus.ToString());
        }
    }
}
