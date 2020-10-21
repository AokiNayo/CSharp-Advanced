using System;
using System.Collections.Generic;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            //StringBuilder text = new StringBuilder();
            string text = String.Empty;
            var myStack = new Stack<char>();

            for (int i = 0; i < n; i++)
            {
                string[] cmd = Console.ReadLine().Split();

                if (cmd[0] == "1")
                {
                    text += cmd[1];
                    myStack.Push(char.Parse(cmd[0]));
                }
                else if (cmd[0] == "2")
                {
                    int count = int.Parse(cmd[1]);
                    text = text.Remove(text.Length - count);
                    myStack.Push(char.Parse(cmd[0]));
                }
                else if (cmd[0] == "3")
                {
                    int index = int.Parse(cmd[1]);
                    Console.WriteLine(text[index - 1]);
                }
                else if (cmd[0] == "4")
                {
                    if (myStack.Peek() == '1')
                    {

                    }
                }

                Console.WriteLine("STACK: ");
                Console.WriteLine(String.Join(" ", myStack));
                Console.WriteLine("TEXT: ");
                Console.WriteLine(text);
            }
        }
    }
}
