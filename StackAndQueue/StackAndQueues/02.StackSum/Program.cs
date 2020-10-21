using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse);

            var myStack = new Stack<int>(numbers);

            while (true)
            {
                var command = Console.ReadLine()
                    .ToLower()
                    .Split();

                if (command[0] == "add")
                {
                    myStack.Push(int.Parse(command[1]));
                    myStack.Push(int.Parse(command[2]));
                }
                else if (command[0] == "remove")
                {
                    var toRemove = int.Parse(command[1]);

                    if (myStack.Count > toRemove)
                    {
                        for (int i = 0; i < toRemove; i++)
                        {
                            myStack.Pop();
                        }
                    }
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine($"Sum: {myStack.Sum()}");
        }
    }
}
