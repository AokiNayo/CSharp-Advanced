using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WildFarm.Core.Contracts;
using WildFarm.Factories;
using WildFarm.Models.Animals;
using WildFarm.Models.Foods;

namespace WildFarm.Core
{
    public class Engine : IEngine
    {
        private ICollection<Animal> animals;

        private readonly AnimalFactory animalFactory;
        private readonly FoodFactory foodFactory;

        public Engine()
        {
            this.animals = new HashSet<Animal>();

            this.animalFactory = new AnimalFactory();
            this.foodFactory = new FoodFactory();
        }
        public void Run()
        {
            string cmd = String.Empty;

            while ((cmd = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string animalType = cmdArgs[0];
                string name = cmdArgs[1];
                double weight = double.Parse(cmdArgs[2]);

                string[] args = cmdArgs.Skip(3).ToArray();
                Animal animal = null;

                try
                {
                    animal = this.animalFactory.Create(animalType, name, weight, args);
                    Console.WriteLine(animal.ProduceSound());

                    this.animals.Add(animal);

                }
                catch (InvalidOperationException msg)
                {
                    Console.WriteLine(msg.Message);
                }

                string[] foodArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string foodType = foodArgs[0];
                int foodQuantity = int.Parse(foodArgs[1]);

                try
                {
                    Food food = foodFactory.CreateFood(foodType, foodQuantity);
                    animal.Feed(food);
                }
                catch (InvalidOperationException msg)
                {
                    Console.WriteLine(msg.Message);
                }
            }
            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
