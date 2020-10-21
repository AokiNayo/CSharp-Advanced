using System;
using System.Collections.Generic;

namespace _04.MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var myStack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                var symbol = input[i];

                if (symbol == '(')
                {
                    myStack.Push(i);
                }
                else if (symbol == ')')
                {
                    int indexOfOpeningBrackets = myStack.Pop();

                    string result = input.Substring(indexOfOpeningBrackets, i - indexOfOpeningBrackets + 1);
                    Console.WriteLine(result);
                }
            }
        }
    }
}
