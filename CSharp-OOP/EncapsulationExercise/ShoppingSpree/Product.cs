using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Product
    {
        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                try
                {
                    if (value == "")
                        throw new Exception("Name cannot be empty");
                    this.name = value;
                }
                catch (Exception msg)
                {
                    Console.WriteLine(msg.Message);
                    Environment.Exit(0);
                }
            }
        }
        public decimal Cost
        {
            get => this.cost;
            private set
            {
                try
                {
                    if (value < 0)
                    {
                        throw new Exception("Money cannot be negative");
                    }
                    this.cost = value;
                }
                catch (Exception msg)
                {
                    Console.WriteLine(msg.Message);
                    Environment.Exit(0);
                }
            }
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
