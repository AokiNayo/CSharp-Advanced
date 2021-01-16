using BorderControl.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl.Models
{
    public class Citizen : IIdentifiable, IBirthable
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            ID = id;
            Birthdate = birthdate;
        }
        
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string ID { get; private set; }
        public string Birthdate { get; private set; }
    }
}
