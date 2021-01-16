﻿using FoodShortage.Interfaces;

namespace FoodShortage.Models
{
    public class Pet : IBirthable
    {
        public Pet(string name, string birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }
        public string Name { get; private set; }
        public string Birthdate { get; private set; }
    }
}
