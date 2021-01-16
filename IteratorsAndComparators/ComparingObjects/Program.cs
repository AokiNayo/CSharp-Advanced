using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = String.Empty;

            List<Person> listOfPeople = new List<Person>();

            while ((input = Console.ReadLine()) != "END")
            {
                var inputArgs = input.Split();

                string name = inputArgs[0];
                int age = int.Parse(inputArgs[1]);
                string town = inputArgs[2];

                Person person = new Person(name, age, town);
                listOfPeople.Add(person);
            }

            int n = int.Parse(Console.ReadLine());

            int samePerson = 0;

            foreach (var item in listOfPeople)
            {
                if (item.CompareTo(listOfPeople[n - 1]) == 0)
                {
                    samePerson++;
                }
            }
            if (samePerson == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{samePerson} {listOfPeople.Count - samePerson} {listOfPeople.Count}");
            }
        }
    }
}
