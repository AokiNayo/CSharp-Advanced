using System;
using System.Collections.Generic;
using System.Linq;

namespace StackAndQueues
{
    class Program
    {
        static void Main(string[] args)
        {
            var myStack = new Stack<char>(Console.ReadLine());

            while (myStack.Any())
            {
                Console.Write(myStack.Pop());
            }
        }
    }
}
