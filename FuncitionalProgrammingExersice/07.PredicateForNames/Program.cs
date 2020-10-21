using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine().Split().ToList();

            Predicate<string> predicate = x => x.Length <= n;
            List<string> newList = SortByLength(names, predicate);

            Func<string, bool> pred = x => x.Length <= n;
            names = names.Where(pred).ToList();

            Console.WriteLine(String.Join(Environment.NewLine, newList));
            Console.WriteLine(String.Join(Environment.NewLine, names));
        }

        static List<string> SortByLength(List<string> names, Predicate<string> predicate)
        {
            List<string> newList = new List<string>();

            foreach (var item in names)
            {
                if (predicate(item))
                {
                    newList.Add(item);
                }
            }
            return newList;
        }
    }
}
