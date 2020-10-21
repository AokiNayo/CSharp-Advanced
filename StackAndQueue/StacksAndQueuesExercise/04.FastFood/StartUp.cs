using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FastFood
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());

            var orderQuantity = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var ordersQueue = new Queue<int>(orderQuantity);
            var biggestOrder = ordersQueue.Max();

            while (ordersQueue.Any())
            {
                if (foodQuantity - ordersQueue.Peek() >= 0)
                {
                    foodQuantity -= ordersQueue.Dequeue();
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(biggestOrder);
            if (ordersQueue.Any())
            {
                Console.WriteLine($"Orders left: {String.Join(" ", ordersQueue)}");
            }
            else
            {
                Console.WriteLine("Orders complete");
            }

        }
    }
}
