using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BasicQueueOperations
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var myQueue = new Queue<int>();

            int n = input[0];
            int s = input[1];
            int x = input[2];

            EnqueueNumbers(numbers, myQueue, n);
            DequeueNumbers(myQueue, s);

            if (myQueue.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(myQueue.Count > 0 ? numbers.Min() : 0);
            }

        }

        static void EnqueueNumbers(int[] numbers, Queue<int> myQueue, int n)
        {
            for (int i = 0; i < n; i++)
            {
                myQueue.Enqueue(numbers[i]);
            }
        }

        static void DequeueNumbers(Queue<int> myQueue, int s)
        {
            for (int i = 0; i < s; i++)
            {
                myQueue.Dequeue();
            }
        }
    }
}
