using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods.Contracts;

namespace WildFarm.Models.Animals.Contracts
{
    public interface IFeedable
    {
        public int FoodEaten { get; }
        public double WeightMultiplier { get; }
        public ICollection<Type> PreferredFoods { get; }
        public void Feed(IFood food);
    }
}
