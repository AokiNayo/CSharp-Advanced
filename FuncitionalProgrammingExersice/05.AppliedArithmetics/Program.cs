using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> myList = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Action<List<int>> print = x => Console.WriteLine(String.Join(" ", myList));
            string cmd = String.Empty;

            while ((cmd = Console.ReadLine()) != "end")
            {
                switch (cmd)
                {
                    case "add":
                        myList = myList.Select(x => x + 1).ToList();
                        break;
                    case "multiply":
                        myList = myList.Select(x => x * 2).ToList();
                        break;
                    case "subtract":
                        myList = myList.Select(x => x - 1).ToList();
                        break;
                    case "print":
                        print(myList);
                        break;
                }
            }
        }
    }
}
