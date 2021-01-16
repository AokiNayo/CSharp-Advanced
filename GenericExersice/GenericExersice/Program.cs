using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericExersice
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> list = new List<int>();

            for (int i = 0; i < n; i++)
            {
                list.Add(int.Parse(Console.ReadLine()));
            }

            int[] index = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int first = index[0];
            int second = index[1];

            SwapMethod(list, first, second);

            foreach (var item in list)
            {
                Console.WriteLine($"{item.GetType()}: {item}");
            }
        }

        public static void SwapMethod<T>(List<T> list, int first, int second)
        {
            var temp = list[first];
            list[first] = list[second];
            list[second] = temp;
        }
    }
}
