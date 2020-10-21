using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] dividers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            List<int> result = new List<int>();
            DivisibleNumbers(n, dividers, result);

            Console.WriteLine(String.Join(" ", result));
        }

        private static void DivisibleNumbers(int n, int[] dividers, List<int> result)
        {
            for (int i = 1; i <= n; i++)
            {
                Predicate<int> divisible = x => i % x != 0;
                bool isTrue = true;

                foreach (var item in dividers)
                {
                    if (divisible(item))
                    {
                        isTrue = false;
                        break;
                    }
                }
                if (isTrue)
                {
                    result.Add(i);
                }
            }
        }
    }
}
