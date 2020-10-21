using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _12.TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split().ToList();

            Func<string, int> getAscii = x => x.Select(x => (int)x).Sum();

            Func<List<string>, int, Func<string, int>, string> func = (names, n, func)
                => names.FirstOrDefault(p =>  func(p) >= n);

            string res = func(names, n, getAscii);
            Console.WriteLine(res);

        }
    }
}
