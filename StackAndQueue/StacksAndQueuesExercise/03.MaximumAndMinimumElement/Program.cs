using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var myStack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                var cmdArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                switch (cmdArgs[0])
                {
                    case "1":
                        myStack.Push(int.Parse(cmdArgs[1]));
                        break;
                    case "2":
                        myStack.Pop();
                        break;
                    case "3":
                        if (myStack.Any())
                            Console.WriteLine(myStack.Max());
                        break;
                    case "4":
                        if (myStack.Any())
                            Console.WriteLine(myStack.Min());
                        break;
                }
            }
            Console.WriteLine(String.Join(", ", myStack));
        }
    }
}

