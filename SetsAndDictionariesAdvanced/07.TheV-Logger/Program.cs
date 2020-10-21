using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _07.TheV_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, SortedSet<string>>> data = new Dictionary<string, Dictionary<string, SortedSet<string>>>();

            string cmd = String.Empty;

            while ((cmd = Console.ReadLine()) != "Statistics")
            {
                string[] cmdArgs = cmd.Split();

                string username = cmdArgs[0];
                string action = cmdArgs[1];
                string followedUser = cmdArgs[2];

                if (action == "joined")
                {
                    if (!data.ContainsKey(username))
                    {
                        data.Add(username, new Dictionary<string, SortedSet<string>>());
                        data[username].Add("followers", new SortedSet<string>());
                        data[username].Add("following", new SortedSet<string>());
                    }
                }
                else if (action == "followed")
                {
                    if (data.ContainsKey(username) && data.ContainsKey(followedUser) && username != followedUser
                        && !(data[username]["following"].Contains(followedUser)))
                    {
                        data[followedUser]["followers"].Add(username);
                        data[username]["following"].Add(followedUser);
                    }
                }
            }

            Console.WriteLine($"The V-Logger has a total of {data.Count} vloggers in its logs.");

            data = data.OrderByDescending(x => x.Value["followers"].Count()).ThenBy(x => x.Value["following"].Count()).ToDictionary(x => x.Key, x => x.Value);
            int n = 1;

            foreach (var bestVlogger in data.Take(1))
            {
                Console.WriteLine($"{n}. {bestVlogger.Key} : {bestVlogger.Value["followers"].Count} followers, {bestVlogger.Value["following"].Count} following");

                foreach (var item in bestVlogger.Value["followers"])
                {
                    Console.WriteLine($"*  {item}");
                }
            }
            foreach (var vloggers in data.TakeLast(data.Keys.Count - 1))
            {
                n++;
                Console.WriteLine($"{n}. {vloggers.Key} : {vloggers.Value["followers"].Count} followers, {vloggers.Value["following"].Count} following");

            }

        }
    }
}
