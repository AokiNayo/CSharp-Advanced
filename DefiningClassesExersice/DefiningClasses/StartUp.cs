using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Family family = new Family();

            for (int i = 0; i < n; i++)
            {
                string[] currentPerson = Console.ReadLine().Split();
                Person person = new Person() { Name = currentPerson[0], Age = int.Parse(currentPerson[1]) };
                family.AddMember(person);
            }

            List<Person> test = family.SortByMoreThanAge();

            foreach (var item in test)
            {
                Console.WriteLine($"{item.Name} - {item.Age}");
            }
        }
    }
}
