using System;
using System.Collections.Generic;

namespace _07.HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            var childrens = Console.ReadLine().Split();
            var toss = int.Parse(Console.ReadLine());

            var myQueue = new Queue<string>(childrens);
            var count = 1;

            while (myQueue.Count > 1)
            {
                if (count == toss)
                {
                    Console.WriteLine($"Removed {myQueue.Dequeue()}");
                    count = 1;
                }
                else
                {
                    myQueue.Enqueue(myQueue.Dequeue());
                    count++;
                }
            }

            Console.WriteLine($"Last is {myQueue.Peek()}");
        }
    }
}
