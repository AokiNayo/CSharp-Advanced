using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] customersInfo = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            List<Person> customers = new List<Person>();
            List<Product> products = new List<Product>();

            for (int i = 0; i < customersInfo.Length; i++)
            {
                var currentCustomer = customersInfo[i].Split("=");

                Person person = new Person(currentCustomer[0], decimal.Parse(currentCustomer[1]));
                customers.Add(person);
            }

            string[] productsInfo = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < productsInfo.Length; i++)
            {
                var currentProduct = productsInfo[i].Split("=");

                Product product = new Product(currentProduct[0], decimal.Parse(currentProduct[1]));
                products.Add(product);
            }

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                var inputArgs = input.Split();

                Person buyer = customers.FirstOrDefault(x => x.Name == inputArgs[0]);
                Product productToBuy = products.FirstOrDefault(x => x.Name == inputArgs[1]);

                buyer.BuyProduct(productToBuy);
            }

            foreach (var item in customers)
            {
                Console.WriteLine(item);
            }
        }
    }
}
