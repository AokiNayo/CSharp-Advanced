using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = String.Empty;

            while ((input = Console.ReadLine()) != "No more tires")
            {
                string[] splitted = input.Split();

                double[] year = splitted.Select(double.Parse)
                    .Where((x,i) => i % 2 ==0)
                    .ToArray();

                double[] pressure = splitted.Select(double.Parse)
                    .Where((x, i) => i % 2 != 0)
                    .ToArray();

                Tire[] currentCarTires = new Tire[4];
                {
                    for (int i = 0; i < currentCarTires.Length; i++)
                    {
                        new Tire((int)year[i], pressure[i]);

                    }
                }

            }

            while ((input = Console.ReadLine()) != "Engines done")
            {

            }
        }
    }
}
