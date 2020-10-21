using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace CarSalesman
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();
            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < n; i++)
            {
                string[] engineArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = engineArgs[0];
                string power = engineArgs[1];

                if (engineArgs.Length == 4)
                {
                    string displacement = engineArgs[2];
                    string efficiency = engineArgs[3];
                    Engine currEngine = new Engine(model, power, displacement, efficiency);
                    engines.Add(currEngine);
                }
                else if (engineArgs.Length == 3)
                {
                    string displacementOrEfficiency = engineArgs[2];
                    int res;
                    bool isTrue = int.TryParse(displacementOrEfficiency, out res);
                    Engine currEngine = new Engine(model, power);

                    if (isTrue)
                    {
                        currEngine.Displacement = displacementOrEfficiency;
                    }
                    else
                    {
                        currEngine.Efficiency = displacementOrEfficiency;
                    }

                    engines.Add(currEngine);
                }
                else
                {
                    Engine currEngine = new Engine(model, power);
                    engines.Add(currEngine);
                }
            }

            int m = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                string[] carArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carArgs[0];
                string engineModel = carArgs[1];
                var currentEngine = engines.FirstOrDefault(x => x.Model == engineModel);

                if (carArgs.Length == 4)
                {
                    string weight = carArgs[2];
                    string color = carArgs[3];
                    Car car = new Car(model, currentEngine, weight, color);
                    cars.Add(car);

                }
                else if (carArgs.Length == 3)
                {
                    string colorOrWeight = carArgs[2];
                    int res;
                    bool isTrue = int.TryParse(colorOrWeight, out res);
                    Car car = new Car(model,currentEngine);

                    if (isTrue)
                    {
                        car.Weight = colorOrWeight;
                    }
                    else
                    {
                        car.Color = colorOrWeight;
                    }
                    cars.Add(car);

                }
                else
                {
                    Car car = new Car(model, currentEngine);
                    cars.Add(car);
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine(  car.ToString());
            }
        }
    }
}
