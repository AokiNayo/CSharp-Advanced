using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bagOfProducts;
        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            bagOfProducts = new List<Product>();
        }
        public string Name
        {
            get => this.name;
            private set
            {
                try
                {
                    if (value == "" || value == null || value == " ")
                    {
                        throw new Exception("Name cannot be empty");
                    }
                    this.name = value;
                }
                catch (Exception msg)
                {
                    Console.WriteLine(msg.Message);
                    Environment.Exit(0);
                }
            }
        }
        public decimal Money
        {
            get => this.money;
            private set
            {
                try
                {
                    if (value < 0)
                    {
                        throw new Exception("Money cannot be negative");
                    }
                    this.money = value;
                }
                catch (Exception msg)
                {
                    Console.WriteLine(msg.Message);
                    Environment.Exit(0);
                }
            }
        }

        public List<Product> BagOfProducts { get => this.bagOfProducts; }

        public void BuyProduct(Product product)
        {
            if (Money >= product.Cost)
            {
                Money -= product.Cost;
                BagOfProducts.Add(product);
                Console.WriteLine($"{this.Name} bought {product.Name}");
            }
            else
            {
                Console.WriteLine($"{Name} can't afford {product.Name}");
            }
        }
        public override string ToString()
        {
            if (BagOfProducts.Count > 0)
            {
                return $"{Name} - {String.Join(", ", BagOfProducts)}";
            }
            else
            {
                return $"{Name} - Nothing bought";
            }
        }
    }
}
