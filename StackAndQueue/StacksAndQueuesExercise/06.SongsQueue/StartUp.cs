using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.SongsQueue
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var songs = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var songList = new Queue<string>(songs);

            while (songList.Any())
            {
                var cmd = Console.ReadLine();

                if (cmd.Contains("Play"))
                {
                    songList.Dequeue();
                }
                else if (cmd.Contains("Add"))
                {
                    var songName = cmd.Substring(4);

                    if (songList.Contains(songName))
                    {
                        Console.WriteLine($"{songName} is already contained!");
                    }
                    else
                    {
                        songList.Enqueue(songName);
                    }
                }
                else if (cmd.Contains("Show"))
                {
                    Console.WriteLine(String.Join(", ", songList));
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}
