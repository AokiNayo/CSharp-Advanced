using System;
using System.Collections.Generic;
using System.Linq;

namespace FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] lilies = Console.ReadLine() //10, 5, 3, 7, 8
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] roses = Console.ReadLine() //5, 10, 8, 7, 6
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> rosesQueue = new Queue<int>(roses);
            Stack<int> liliesStack = new Stack<int>(lilies);

            int wreath = 0;
            int stored = 0;

            while (rosesQueue.Any() && liliesStack.Any())
            {
                int flowersSum = rosesQueue.Peek() + liliesStack.Peek();

                if (flowersSum == 15)
                {
                    wreath++;
                    rosesQueue.Dequeue();
                    liliesStack.Pop();
                }
                else if (flowersSum < 15)
                {
                    stored += rosesQueue.Dequeue() + liliesStack.Pop();
                }
                else if (flowersSum > 15)
                {
                    liliesStack.Push(liliesStack.Pop() - 2);
                }
            }
            wreath += stored / 15;

            Console.WriteLine(wreath >= 5 ? $"You made it, you are going to the competition with {wreath} wreaths!" 
                : $"You didn't make it, you need {5-wreath} wreaths more!");
        }
    }
}
