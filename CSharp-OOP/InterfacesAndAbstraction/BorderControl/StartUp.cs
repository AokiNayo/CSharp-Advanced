using BorderControl.Interfaces;
using BorderControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var input = String.Empty;

            List<IIdentifiable> society = new List<IIdentifiable>();
            List<IBirthable> birthdate = new List<IBirthable>();

            while ((input = Console.ReadLine()) != "End")
            {
                var inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (inputArgs[0] == "Citizen")
                {
                    Citizen citizen = new Citizen(inputArgs[1], int.Parse(inputArgs[2]), inputArgs[3], inputArgs[4]);
                    society.Add(citizen);
                    birthdate.Add(citizen);
                }
                else if (inputArgs[0] == "Robot")
                {
                    Robot robot = new Robot(inputArgs[1], inputArgs[2]);
                    society.Add(robot);
                }
                else if (inputArgs[0] == "Pet")
                {
                    Pet pet = new Pet(inputArgs[1], inputArgs[2]);
                    birthdate.Add(pet);
                }
            }

            input = Console.ReadLine();

            foreach (var item in birthdate.Where(x => x.Birthdate.EndsWith(input)))
            {
                Console.WriteLine(item.Birthdate);
            }
        }
    }
}
