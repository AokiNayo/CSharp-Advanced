using System;
using System.Collections.Generic;
using System.Linq;

namespace StacksAndQueuesExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var cmdArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var myStack = new Stack<int>();
            var minValue = int.MaxValue;
            var isTrue = true;
            var count = 0;

            int n = cmdArr[0];
            int s = cmdArr[1];
            int x = cmdArr[2];

            for (int i = 0; i < n; i++)
            {
                myStack.Push(numbers[i]);
            }
            for (int j = 0; j < s; j++)
            {
                myStack.Pop();
            }

            while (myStack.Any())
            {
                count++;
                isTrue = false;

                var currentNum = 0;
                if ((currentNum = myStack.Pop()) == x)
                {
                    count = 0;
                    Console.WriteLine("true");
                    break;
                }
                if (minValue > currentNum)
                {
                    minValue = currentNum;
                }
            }
            if (count > 0)
            {
                Console.WriteLine(minValue);
            }
            if (isTrue)
            {
                Console.WriteLine(0);
            }
        }
    }
}
