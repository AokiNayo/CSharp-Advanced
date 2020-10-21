using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split()
                .ToArray();

            var myStack = new Stack<string>(input.Reverse());

            while (myStack.Count > 1)
            {
                var firstNum = int.Parse(myStack.Pop());
                var operation = myStack.Pop();
                var secondNum = int.Parse(myStack.Pop());

                var tempResult = operation switch
                {
                    "+" => (firstNum + secondNum),
                    "-" => (firstNum - secondNum),
                    _ => 0
                };

                myStack.Push(tempResult.ToString());
            }
            Console.WriteLine(myStack.Peek());
        }
    }
}
