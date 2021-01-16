using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Cake : Dessert
    {
        private decimal cakePrice = 5;
        private double grams = 250;
        private double calories = 1000;

        public Cake(string name) : base(name, 0, 0, 0)
        {

        }

        public override decimal Price { get => this.cakePrice; }
        public override double Grams { get => this.grams; }
        public override double Calories { get => this.calories; }
    }
}
