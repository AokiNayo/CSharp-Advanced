using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<int, int> evenTimes = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int inputNum = int.Parse(Console.ReadLine());

                if (!evenTimes.ContainsKey(inputNum))
                {
                    evenTimes.Add(inputNum, 0);
                }
                evenTimes[inputNum]++;
            }

            foreach (var kvp in evenTimes.Where(x => x.Value % 2 == 0).ToDictionary(x => x.Key, x => x.Value))
            {
                Console.WriteLine(kvp.Key);
            }
        }
    }
}
