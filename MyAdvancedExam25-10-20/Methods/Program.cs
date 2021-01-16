using System;
using System.Collections.Generic;
using System.Linq;

namespace Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> tasks = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse));
            Queue<int> thread = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse));

            int taskToKill = int.Parse(Console.ReadLine());

            while (tasks.Any() && thread.Any())
            {
                if (tasks.Peek() == taskToKill)
                {
                    break;
                }
                else if (thread.Peek() >= tasks.Peek())
                {
                    thread.Dequeue();
                    tasks.Pop();
                }
                else if (thread.Peek() < tasks.Peek())
                {
                    thread.Dequeue();
                }
            }
            Console.WriteLine($"Thread with value {thread.Peek()} killed task {taskToKill}");
            Console.WriteLine(String.Join(" ", thread));
        }
    }
}
