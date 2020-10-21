using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace _11.PartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> invited = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<string> filters = new List<string>();

            string cmd;

            while ((cmd = Console.ReadLine()) != "Print")
            {
                string[] cmdArgs = cmd.Split(";");

                if (cmdArgs[0] == "Add filter")
                {
                    filters.Add($"{cmdArgs[1]};{cmdArgs[2]}");
                }
                else if (cmdArgs[0] == "Remove filter")
                {
                    filters.Remove($"{cmdArgs[1]};{cmdArgs[2]}");
                }
            }

            foreach (var item in filters)
            {
                string[] tokens = item.Split(";");

                switch (tokens[0])
                {
                    case "Starts with":
                        invited = invited.Where(x => !x.StartsWith(tokens[1])).ToList();
                        break;
                    case "Ends with":
                        invited = invited.Where(x => !x.EndsWith(tokens[1])).ToList();
                        break;
                    case "Length":
                        invited = invited.Where(x => x.Length != int.Parse(tokens[1])).ToList();
                        break;
                    case "Contains":
                        invited = invited.Where(x => !x.Contains(tokens[1])).ToList();
                        break;
                }
            }
            Console.WriteLine(String.Join(" ", invited));
        }
        static void GetPredicate(string[] cmdArgs, List<string> invited)
        {
            Predicate<string> predicate = null;

            string cmd = cmdArgs[1];

            switch (cmdArgs[1])
            {
                case "Starts with":
                    predicate = x => !x.StartsWith(cmdArgs[2]);
                    break;
                case "Ends with":
                    predicate = x => !x.EndsWith(cmdArgs[2]);
                    break;
                case "Length":
                    predicate = x => x.Length != int.Parse(cmdArgs[2]);
                    break;
                case "Contains":
                    predicate = x => !x.Contains(cmdArgs[2]);
                    break;
            }
        }
    }
}
