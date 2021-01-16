using System;
using System.Collections.Generic;
using System.Linq;

namespace ClubParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());

            Stack<string> stack = new Stack<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));
            Queue<string> queue = new Queue<string>();

            List<int> people = new List<int>();
            int sum = 0;

            while (stack.Any())
            {
                var curr = stack.Pop();

                if (Char.IsLetter(curr[0]))
                {
                    queue.Enqueue(curr);
                }
                else
                {
                    if (queue.Any())
                    {
                        if (sum + int.Parse(curr) > capacity)
                        {
                            Console.WriteLine($"{queue.Dequeue()} -> {String.Join(", ", people)}");
                            people = new List<int>();
                            sum = 0;
                        }
                        if (queue.Any())
                        {
                            people.Add(int.Parse(curr));
                            sum += int.Parse(curr);
                        }
                    }
                }
            }

        }
    }
}
