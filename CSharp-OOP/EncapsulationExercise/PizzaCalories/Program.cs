using System;

namespace PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            var pizzaArgs = Console.ReadLine().Split();
            var doughArgs = Console.ReadLine().Split();

            var dough = new Dough(doughArgs[1], doughArgs[2], double.Parse(doughArgs[3]));
            var pizza = new Pizza(pizzaArgs[1], dough);

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                var inputArgs = input.Split();

                var toppings = new Topping(inputArgs[1], double.Parse(inputArgs[2]));
                pizza.AddToppings(toppings);
            }

            Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:F2} Calories.");
        }
    }
}
