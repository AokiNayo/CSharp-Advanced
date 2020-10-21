using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutique
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var clothesValue = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rackCapacity = int.Parse(Console.ReadLine());

            var boxOfClothes = new Stack<int>(clothesValue);

            var sum = 0;
            var racksCount = 1;

            while (boxOfClothes.Any())
            {
                if (rackCapacity < sum + boxOfClothes.Peek())
                {
                    racksCount++;
                    sum = 0;
                }
                sum += boxOfClothes.Pop();
            }
            Console.WriteLine(racksCount);
        }
    }
}