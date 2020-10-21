using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TruckTour
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var pumps = new Queue<int[]>();

            for (int i = 0; i < n; i++)
            {
                var currentPump = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                pumps.Enqueue(currentPump);
            }

            int counter = 0;

            while (true)
            {
                int fuelAmount = 0;
                bool foundPoint = true;

                foreach (var pump in pumps)
                {
                    fuelAmount += pump[0];

                    if (fuelAmount < pump[1])
                    {
                        foundPoint = false;
                        break;
                    }

                    fuelAmount -= pump[1];
                }

                if (foundPoint)
                {
                    break;
                }

                counter++;
                pumps.Enqueue(pumps.Dequeue());
            }
            Console.WriteLine(counter);
        }

    }
}
