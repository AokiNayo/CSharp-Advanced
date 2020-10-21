using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PredicateParty_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> invited = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Distinct()
                .ToList();

            string cmd = Console.ReadLine();

            while (cmd != "Party!")
            {
                string[] cmdArgs = cmd.Split();

                Predicate<string> predicate = GetPredicate(cmdArgs);

                if (cmdArgs[0] == "Remove")
                {
                    invited.RemoveAll(predicate);
                }
                else if (cmdArgs[0] == "Double")
                {
                    for (int i = 0; i < invited.Count; i++)
                    {
                        if (predicate(invited[i]))
                        {
                            invited.Insert(i + 1, invited[i]);
                            i++;
                        }
                    }
                }
                cmd = Console.ReadLine();
            }

            if (invited.Count > 0)
            {
                Console.Write(String.Join(", ", invited));
                Console.WriteLine(" are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        static Predicate<string> GetPredicate(string[] cmdArgs)
        {
            Predicate<string> predicate = null;

            switch (cmdArgs[1])
            {
                case "StartsWith":
                    predicate = x => x.StartsWith(cmdArgs[2]);
                    break;
                case "EndsWith":
                    predicate = x => x.EndsWith(cmdArgs[2]);
                    break;
                case "Length":
                    predicate = x => x.Length == int.Parse(cmdArgs[2]);
                    break;
            }

            return predicate;
        }
    }
}
