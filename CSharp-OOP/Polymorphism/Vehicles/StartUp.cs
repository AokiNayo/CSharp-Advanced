using System;

namespace Vehicles
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var carArgs = Console.ReadLine().Split();
            var truckArgs = Console.ReadLine().Split();

            Vehicle car = new Car(double.Parse(carArgs[1]), double.Parse(carArgs[2]));
            Vehicle truck = new Truck(double.Parse(truckArgs[1]), double.Parse(truckArgs[2]));


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
                    else
                    {
                        truck.Drive(double.Parse(cmdArgs[2]));
                    }
                }
                else
                {
                    if (cmdArgs[1] == "Car")
                    {
                        car.Refuel(double.Parse(cmdArgs[2]));
                    }
                    else
                    {
                        truck.Refuel(double.Parse(cmdArgs[2]));

                    }
                }
            }
            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
        }
    }
}
