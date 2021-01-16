using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Animals
{
    public abstract class Mammal : Animal
    {
        protected Mammal(string name, double weight, string livingRegion) 
            : base(name, weight)
        {
            this.LivingReagion = livingRegion;
        }

        public string LivingReagion { get; }

        public override string ToString()
        {
            return base.ToString() + $"{this.Weight}, {this.LivingReagion}, {FoodEaten}]";
        }
    }
}
