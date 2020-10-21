using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] lilies = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[] roses = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            Stack<int> liliesStack = new Stack<int>(lilies);
            Queue<int> rosesQueue = new Queue<int>(roses);
            int storedFlowers = 0;
            int wreath = 0;

            while (liliesStack.Any() && rosesQueue.Any())
            {
                if (liliesStack.Peek() + rosesQueue.Peek() == 15)
                {
                    liliesStack.Pop();
                    rosesQueue.Dequeue();
                    wreath++;
                }
                else if (liliesStack.Peek() + rosesQueue.Peek() > 15)
                {
                    int A = liliesStack.Pop();
                    int B = rosesQueue.Dequeue();
                    int C = 0;

                    while (C <= 15)
                    {
                        A -= 2;
                        C = A + B;
                    }
                    if (C < 15)
                    {
                        storedFlowers += C;
                    }
                    else if (C == 15)
                    {
                        wreath++;
                    }
                }
                else if (liliesStack.Peek() + rosesQueue.Peek() < 15)
                {
                    storedFlowers += liliesStack.Pop() + rosesQueue.Dequeue();
                }
            }
            wreath += storedFlowers / 15;
            Console.WriteLine(wreath);
            Console.WriteLine(storedFlowers);
        }
    }
}
