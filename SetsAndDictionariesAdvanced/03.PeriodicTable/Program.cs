using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            SortedSet<string> chemicalElements = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] element = Console.ReadLine().Split(" ").ToArray();

                for (int j = 0; j < element.Length; j++)
                {
                    chemicalElements.Add(element[j]);
                }
            }

            Console.WriteLine(String.Join(" ", chemicalElements));
        }
    }
}
