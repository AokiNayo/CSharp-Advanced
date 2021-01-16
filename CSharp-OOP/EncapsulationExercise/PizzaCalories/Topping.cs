using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private const double caloriesPerGram = 2;
        private const double meat = 1.2;
        private const double veggies = 0.8;
        private const double cheese = 1.1;
        private const double sauce = 0.9;

        private string type;
        private double weight;

        public Topping(string type, double weight)
        {
            Type = type;
            Weight = weight;
        }

        public string Type
        {
            get => this.type;
            private set
            {
                try
                {
                    if (value.ToLower() == "meat" || value.ToLower() == "veggies" || value.ToLower() == "cheese" || value.ToLower() == "sauce")
                    {
                        this.type = value;
                    }
                    else
                    {
                        throw new Exception($"Cannot place {value} on top of your pizza.");
                    }
                }
                catch (Exception msg)
                {
                    Console.WriteLine(msg.Message);
                    Environment.Exit(0);
                }
            }
        }
        public double Weight
        {
            get => this.weight;
            private set
            {
                try
                {
                    if (value < 1 || value > 50)
                    {
                        throw new ArgumentException($"{Type} weight should be in the range [1..50].");
                    }
                    this.weight = value;
                }
                catch (ArgumentException msg)
                {
                    Console.WriteLine(msg.Message);
                    Environment.Exit(0);
                }
            }
        }


        public double CalculateCaloires()
        {
            double result = 0;

            switch (type.ToLower())
            {
                case "meat": result = meat * weight * caloriesPerGram;
                    break;
                case "veggies": result = veggies * weight * caloriesPerGram;
                    break;
                case "cheese": result = cheese * weight * caloriesPerGram;
                    break;
                case "sauce": result = sauce * weight * caloriesPerGram;
                    break;
            }
            return result;
        }
    }
}
