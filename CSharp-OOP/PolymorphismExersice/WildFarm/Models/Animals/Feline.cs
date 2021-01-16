using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Animals
{
    public abstract class Feline : Mammal
    {
        protected Feline(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion)
        {
            this.Breed = breed;

        }
        public string Breed { get; }

        public override string ToString()
        {
            return $"{GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingReagion}, {this.FoodEaten}]";
        }

    }
}
