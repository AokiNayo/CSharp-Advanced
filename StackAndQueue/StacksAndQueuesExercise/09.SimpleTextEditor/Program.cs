using System;
using System.Collections.Generic;
using System.Text;

namespace _09.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            StringBuilder text = new StringBuilder();

            Stack<string> stack = new Stack<string>();
            stack.Push(text.ToString());

            for (int i = 0; i < n; i++)
            {
                var cmdArgs = Console.ReadLine().Split();
                string cmdName = cmdArgs[0];

                if (cmdName == "1")
                {
                    text.Append(cmdArgs[1]);
                    stack.Push(text.ToString());
                }
                else if (cmdName == "2")
                {
                    int index = int.Parse(cmdArgs[1]);
                    text.Remove(text.Length - index, index);
                    stack.Push(text.ToString());
                }
                else if (cmdName == "3")
                {
                    int index = int.Parse(cmdArgs[1]);
                    Console.WriteLine(text[index - 1]);
                }
                else if (cmdName == "4")
                {
                    stack.Pop();
                    text = new StringBuilder(stack.Peek());
                }
            }
        }
    }
}
