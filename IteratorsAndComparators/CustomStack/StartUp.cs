using System;
using System.Linq;
using System.Security.Cryptography;

namespace CustomStack
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string cmd = String.Empty;
            CustomStack<int> myStack = new CustomStack<int>();

            while ((cmd = Console.ReadLine()) != "END")
            {
                if (cmd.Contains("Push"))
                {
                    var cmdArgs = cmd.Substring(5).Split(", ").Select(int.Parse).ToArray();

                    for (int i = 0; i < cmdArgs.Length; i++)
                    {
                        myStack.Push(cmdArgs[i]);
                    }
                }
                else if (cmd == "Pop")
                {
                    try
                    {
                        myStack.Pop();
                    }
                    catch (InvalidOperationException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            try
            {
                for (int i = 0; i < 2; i++)
                {
                    foreach (var item in myStack)
                    {
                        Console.WriteLine(item);
                    }
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
