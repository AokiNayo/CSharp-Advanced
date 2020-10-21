using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace _06.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> colors = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] inputArgs = Console.ReadLine().Split(" -> ").ToArray();
                string color = inputArgs[0];

                string[] cloths = inputArgs[1].Split(",").ToArray();

                if (!colors.ContainsKey(color))
                {
                    colors.Add(color, new Dictionary<string, int>());
                }

                for (int j = 0; j < cloths.Length; j++)
                {
                    if (!colors[color].ContainsKey(cloths[j]))
                    {
                        colors[color].Add(cloths[j], 0);
                    }
                    colors[color][cloths[j]]++;
                }
            }
            string[] lookingFor = Console.ReadLine().Split();

            foreach (var currentColor in colors)
            {
                Console.WriteLine($"{currentColor.Key} clothes:");
                foreach (var cloth in currentColor.Value)
                {
                    if (lookingFor[0] == currentColor.Key && cloth.Key == lookingFor[1])
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value}");
                    }
                }
            }

        }
    }
}
