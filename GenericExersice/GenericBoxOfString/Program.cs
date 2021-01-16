using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericBoxOfString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var firstLine = Console.ReadLine().Split();
            string fullName = firstLine[0] + " " + firstLine[1];
            string adress = firstLine[2];
            string town = firstLine[3];

            Threeuple<string, string, string> firstPerson = new Threeuple<string, string, string>(fullName, adress, town);
            Console.WriteLine(firstPerson);

            var secondLine = Console.ReadLine().Split();
            string secondName = secondLine[0];
            int beerAmount = int.Parse(secondLine[1]);
            bool isDrunk = false;

            if (secondLine[2] == "drunk")
                isDrunk = true;

            Threeuple<string, int, bool> secondPerson = new Threeuple<string, int, bool>(secondName, beerAmount, isDrunk);
            Console.WriteLine(secondPerson);

            var thirdLine = Console.ReadLine().Split();
            string name = thirdLine[0];
            double decimalNumber = double.Parse(thirdLine[1]);
            string bankName = thirdLine[2];

            Threeuple<string, double, string> thirdPerson = new Threeuple<string, double, string>(name, decimalNumber, bankName);
            Console.WriteLine(thirdPerson);


        }
    }
}