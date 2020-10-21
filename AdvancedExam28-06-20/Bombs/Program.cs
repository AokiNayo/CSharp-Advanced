using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] bombEffect = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] bombCasing = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int daturaBombs = 0;
            int cherryBombs = 0;
            int smokeDecoy = 0;

            Queue<int> effect = new Queue<int>(bombEffect);
            Stack<int> casing = new Stack<int>(bombCasing);

            while (true)
            {
                if (daturaBombs >= 3 && cherryBombs >= 3 && smokeDecoy >= 3)
                {
                    break;
                }
                if (!effect.Any() || !casing.Any())
                {
                    break;
                }    
                var test = effect.Peek() + casing.Peek();

                if (test == 40)
                {
                    daturaBombs++;
                    casing.Pop();
                    effect.Dequeue();
                }
                else if (test == 60)
                {
                    cherryBombs++;
                    casing.Pop();
                    effect.Dequeue();
                }
                else if (test == 120)
                {
                    smokeDecoy++;
                    casing.Pop();
                    effect.Dequeue();
                }
                else
                {
                    casing.Push(casing.Pop() - 5);
                }
            }
            if (daturaBombs >= 3 && cherryBombs >= 3 && smokeDecoy >= 3)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (effect.Any())
            {
                Console.Write("Bomb Effects: ");
                Console.WriteLine(String.Join(", ", effect));
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            if (casing.Any())
            {
                Console.Write("Bomb Casings: ");
                Console.WriteLine(String.Join(", ", casing));
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }

            Console.WriteLine($"Cherry Bombs: {cherryBombs}");
            Console.WriteLine($"Datura Bombs: {daturaBombs}");
            Console.WriteLine($"Smoke Decoy Bombs: {smokeDecoy}");
        }

    }
}
