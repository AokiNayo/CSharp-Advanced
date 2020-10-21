using System;
using System.Collections.Generic;

namespace FuncitionalProgrammingExersice
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] numRange = Console.ReadLine().Split();

            int start = int.Parse(numRange[0]);
            int end = int.Parse(numRange[1]);
            string action = Console.ReadLine();

            Func<int, int, List<int>> func = FillListInRange;
            List<int> numbers = func(start, end);

            Predicate<int> myPredicate = x => x % 2 == 0;

            if (action == "odd")
            {
                myPredicate = x => x % 2 != 0;
            }

            numbers = ReturnNewOddOrEvenList(numbers, myPredicate);
            Console.WriteLine(String.Join(" ", numbers));
        }

        static List<int> FillListInRange(int start, int end)
        {
            List<int> newList = new List<int>();

            for (int i = start; i <= end; i++)
            {
                newList.Add(i);
            }
            return newList;
        }
        static List<int> ReturnNewOddOrEvenList(List<int> nums, Predicate<int> predicate)
        {
            List<int> res = new List<int>();

            foreach (var item in nums)
            {
                if (predicate(item))
                {
                    res.Add(item);
                }
            }
            return res;
        }
    }
}
