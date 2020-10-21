using System;
using System.Collections.Generic;

namespace SpeedRacing
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] carArgs = Console.ReadLine().Split();

                Car currentCar = new Car(carArgs[0], double.Parse(carArgs[1]), double.Parse(carArgs[2]));
                cars.Add(currentCar);
            }

            string cmd = String.Empty;

            while ((cmd = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = cmd.Split();

                var car = cars.Find(x => x.Model == cmdArgs[1]);
                car.Drive(double.Parse(cmdArgs[2]));
            }

            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
