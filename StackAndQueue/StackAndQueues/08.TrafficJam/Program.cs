using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var myQueue = new Queue<string>();
            var carPassed = 0;

            while (true)
            {
                var cmd = Console.ReadLine();

                if (cmd == "end")
                {
                    break;
                }
                else if (cmd == "green")
                {
                    for (int i = 0; i < n && myQueue.Any(); i++) // n && myQueue.Any() == if () внутри цикла
                    {
                        Console.WriteLine($"{myQueue.Dequeue()} passed!");
                        carPassed++;
                    }
                }
                else
                {
                    myQueue.Enqueue(cmd);
                }
            }
            Console.WriteLine($"{carPassed} cars passed the crossroads.");
        }
    }
}
