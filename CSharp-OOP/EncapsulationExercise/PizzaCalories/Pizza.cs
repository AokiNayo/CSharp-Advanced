using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;


        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.dough = dough;
            toppings = new List<Topping>();
            TotalCalories += dough.CalculateCalories();
        }
        public double TotalCalories { get; set; }

        public string Name
        {
            get => this.name;
            set
            {
                try
                {
                    if (value.Length < 1 && value.Length > 15)
                    {
                        throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                    }
                    this.name = value;
                }
                catch (ArgumentException msg)
                {
                    Console.WriteLine(msg.Message);
                    Environment.Exit(0);
                }
            }
        }
        public void AddToppings(Topping topping)
        {
            try
            {
                if (toppings.Count >= 10)
                {
                    throw new ArgumentException("Number of toppings should be in range [0..10].");
                }
                else
                {
                    this.toppings.Add(topping);
                    TotalCalories += topping.CalculateCaloires();
                }
            }
            catch (ArgumentException msg)
            {
                Console.WriteLine(msg.Message);
                Environment.Exit(0);
            }
        }
    }
}
