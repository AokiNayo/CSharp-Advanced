using System;

namespace Demo1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] cmdArgs = Console.ReadLine().Split(";");

            Predicate<string> predicate = null;

            switch (cmdArgs[1])
            {
                case "Starts with": predicate = x => x.StartsWith(cmdArgs[2]);
                    break;
                default:
                    break;
            }
        }
    }
}
