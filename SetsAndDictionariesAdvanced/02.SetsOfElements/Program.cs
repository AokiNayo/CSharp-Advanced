using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int n = nums[0];
            int m = nums[1];

            HashSet<int> firstN = new HashSet<int>(n);
            HashSet<int> secondM = new HashSet<int>(m);

            for (int i = 0; i < n; i++)
            {
                int inputNum = int.Parse(Console.ReadLine());

                firstN.Add(inputNum);
            }
            for (int i = 0; i < m; i++)
            {
                int inputNum = int.Parse(Console.ReadLine());

                secondM.Add(inputNum);
            }

            Console.WriteLine(string.Join(" ", firstN.Intersect(secondM)));
        }
    }
}
