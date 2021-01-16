using System;
using System.Text;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var newPerson = new Person(10);

            newPerson.GetType().GetProperty("Age").SetValue(newPerson, 25);

            Console.WriteLine();


        }

    }
}
