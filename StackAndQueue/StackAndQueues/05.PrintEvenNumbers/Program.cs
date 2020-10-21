using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> myQueue = new Queue<int>();

            foreach (var number in numbers)
            {
                if (number % 2 == 0)
                {
                    myQueue.Enqueue(number);
                }
            }
            
            Console.WriteLine(String.Join(", ", myQueue));


        }
    }
}
