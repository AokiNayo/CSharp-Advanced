using System;
using System.Collections.Generic;
using System.Text;

namespace Reflection
{
    public class Person
    {
        public Person(int age)
        {
            this.Age = age;

        }
        public Person(int age, int secondAge)
        {

        }
        public string Name { get; set; }
        public int Age { get; set; }


    }
}
