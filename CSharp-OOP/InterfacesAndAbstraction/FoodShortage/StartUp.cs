using FoodShortage.Models;
using FoodShortage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<IBuyer> people = new List<IBuyer>();

            for (int i = 0; i < n; i++)
            {
                var personInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (personInfo.Length == 4)
                {
                    Citizen citizen = new Citizen(personInfo[0], int.Parse(personInfo[1]), personInfo[2], personInfo[3]);
                    people.Add(citizen);
                }
                else
                {
                    Rebel rebel = new Rebel(personInfo[0], int.Parse(personInfo[1]), personInfo[2]);
                    people.Add(rebel);
                }
            }

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                var currentBuyer = people.FirstOrDefault(x => x.Name == input);

                if (currentBuyer != null)
                    currentBuyer.BuyFood();
            }

            Console.WriteLine(people.Sum(x => x.Food));
        }
    }
}
