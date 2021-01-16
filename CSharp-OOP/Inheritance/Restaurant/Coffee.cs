using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private double coffeeMilliliters = 50;
        private decimal coffeePrice = 3.50m;

        public Coffee(string name, double caffeine) : base(name, 0, 0)
        {
            Caffeine = caffeine;
        }

        public override double Milliliters { get => this.coffeeMilliliters; }
        public override decimal Price { get => this.coffeePrice; }
        public double Caffeine { get; set; }

    }
}
