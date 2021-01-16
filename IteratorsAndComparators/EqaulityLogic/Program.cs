using System;
using System.Collections.Generic;

namespace EqaulityLogic
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            SortedSet<Person> sortedSet = new SortedSet<Person>();
            HashSet<Person> hashSet = new HashSet<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] person = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Person currentPerson = new Person(person[0], int.Parse(person[1]));

                sortedSet.Add(currentPerson);
                hashSet.Add(currentPerson);
            }
            Console.WriteLine(sortedSet.Count);
            Console.WriteLine(hashSet.Count);
        }
    }
}
