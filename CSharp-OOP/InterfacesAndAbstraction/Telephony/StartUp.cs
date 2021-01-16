using System;
using System.Collections.Generic;
using System.Linq;
using Telephony.Exeptions;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split();
            string[] URLs = Console.ReadLine().Split();

            Smartphone smartPhone = new Smartphone();
            StationaryPhone stationaryPhone = new StationaryPhone();

            foreach (var item in phoneNumbers)
            {
                try
                {
                    if (item.Length == 10)
                    {
                        Console.WriteLine(smartPhone.MakeCall(item));
                    }
                    else if (item.Length == 7)
                    {
                        Console.WriteLine(stationaryPhone.MakeCall(item));
                    }
                    else
                    {
                        throw new InvalidNumberExeption();
                    }
                }
                catch (InvalidNumberExeption ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var item in URLs)
            {
                try
                {
                    Console.WriteLine(smartPhone.Browse(item));
                }
                catch (InvalidURLExeption ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
