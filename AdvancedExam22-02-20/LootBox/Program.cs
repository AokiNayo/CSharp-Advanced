using System;
using System.Collections.Generic;
using System.Linq;

namespace LootBox
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> first = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> second = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            List<int> items = new List<int>();

            while (first.Any() && second.Any())
            {
                if ((first.Peek() + second.Peek()) % 2 == 0)
                {
                    items.Add(first.Dequeue() + second.Pop());
                }
                else
                {
                    first.Enqueue(second.Pop());
                }
            }
            if (!first.Any())
            {
                Console.WriteLine("First lootbox is empty");
            }
            if (!second.Any())
            {
                Console.WriteLine("Second lootbox is empty");
            }
            Console.WriteLine(items.Sum() >= 100 ? $"Your loot was epic! Value: {items.Sum()}" : $"Your loot was poor... Value: {items.Sum()}");
        }
    }
}
