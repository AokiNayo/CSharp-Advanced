using System;
using System.Collections.Generic;

namespace _06.Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            var myQueue = new Queue<string>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }
                else if (input == "Paid")
                {
                    while (myQueue.Count > 0)
                    {
                        Console.WriteLine($"{myQueue.Dequeue()}");
                    }
                }
                else
                {
                    myQueue.Enqueue(input);
                }
            }
            Console.WriteLine($"{myQueue.Count} people remaining.");
        }
    }
}
