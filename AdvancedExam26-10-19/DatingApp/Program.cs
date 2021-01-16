using System;
using System.Collections.Generic;
using System.Linq;

namespace DatingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> males = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            Queue<int> females = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

            int match = 0;

            while (males.Any() && females.Any())
            {
                if (males.Peek() != 0 && males.Peek() % 25 == 0 || females.Peek() != 0 && females.Peek() % 25 == 0)
                {
                    if (males.Peek() % 25 == 0)
                    {
                        males.Pop();
                        males.Pop();
                    }
                    if (females.Peek() % 25 == 0)
                    {
                        females.Dequeue();
                        females.Dequeue();
                    }
                }
                else if (males.Peek() == females.Peek())
                {
                    match++;
                    males.Pop();
                    females.Dequeue();
                }
                else if (males.Peek() <= 0 || females.Peek() <= 0)
                {
                    if (males.Peek() <= 0)
                    {
                        males.Pop();
                    }
                    if (females.Peek() <= 0)
                    {
                        females.Dequeue();
                    }
                }
                else if (males.Peek() != females.Peek())
                {
                    females.Dequeue();
                    males.Push(males.Pop() - 2);
                }
            }
            Console.WriteLine($"Matches: {match}");
            Console.WriteLine(males.Count > 0 ? $"Males left: {String.Join(", ", males)}" : $"Males left: none");
            Console.WriteLine(females.Count > 0 ? $"Females left: {String.Join(", ", females)}" : $"Females left: none");

        }
    }
}
