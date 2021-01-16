using System;
using System.Collections.Generic;
using System.Linq;

namespace SantasPresentFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> materials = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Queue<int> magicLevel = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            List<Present> toys = new List<Present>();

            toys.Add(new Present("Doll", 150));
            toys.Add(new Present("Wooden train", 250));
            toys.Add(new Present("Teddy bear", 300));
            toys.Add(new Present("Bicycle", 400));

            while (materials.Any() && magicLevel.Any())
            {
                int sum = materials.Peek() * magicLevel.Peek();

                if (toys.Any(x => x.Required == sum))
                {
                    toys.FirstOrDefault(x => x.Required == sum).Made++;
                    materials.Pop();
                    magicLevel.Dequeue();
                }
                else if (sum > 0)
                {
                    magicLevel.Dequeue();
                    materials.Push(materials.Pop() + 15);
                }
                else if (sum < 0)
                {
                    materials.Push(materials.Pop() + magicLevel.Dequeue());
                }
                else if (sum == 0)
                {
                    if (materials.Peek() == 0)
                    {
                        materials.Pop();
                    }
                    if (magicLevel.Peek() == 0)
                    {
                        magicLevel.Dequeue();
                    }
                }
            }
            if ((toys.Any(x => x.Name == "Doll" && x.Made > 0) && toys.Any(x => x.Name == "Wooden train" && x.Made > 0)) ||
                (toys.Any(x => x.Name == "Teddy bear" && x.Made > 0) && toys.Any(x => x.Name == "Bicycle" && x.Made > 0)))
            {
                Console.WriteLine("The presents are crafted! Merry Christmas!");
            }
            else
            {
                Console.WriteLine($"No presents this Christmas!");
            }
            if (materials.Any())
            {
                Console.WriteLine($"Materials left: {String.Join(", ", materials)}");

            }
            if (magicLevel.Any())
            {
                Console.WriteLine($"Magic left: {String.Join(", ", magicLevel)}");

            }

            foreach (var item in toys.Where(x => x.Made > 0).OrderBy(x => x.Name))
            {
                Console.WriteLine($"{item.Name}: {item.Made}");
            }
        }

        public class Present
        {
            public Present(string name, int required)
            {
                this.Name = name;
                this.Required = required;
            }
            public string Name { get; set; }
            public int Required { get; set; }
            public int Made { get; set; }


        }
    }
}