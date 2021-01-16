using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private ICollection<IBakedFood> foodCollection;
        private ICollection<IDrink> drinksCollection;

        private int capacity;
        private int numberOfPeople;

        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            foodCollection = new List<IBakedFood>();
            drinksCollection = new List<IDrink>();

            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
        }

        public int TableNumber { get; }

        public int Capacity
        {
            get => this.capacity;
            private set
            {
                if (value < 0) 
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }

                this.capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get => this.numberOfPeople;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }

                this.numberOfPeople = value;
            }
        }
        public decimal PricePerPerson { get; }

        // TODO: Check those 2 properties
        public bool IsReserved => NumberOfPeople > 0;
        public decimal Price => PricePerPerson * NumberOfPeople;
        //
        public void Reserve(int numberOfPeople)
        {
            this.NumberOfPeople = numberOfPeople;
        }

        public void OrderFood(IBakedFood food)
        {
            foodCollection.Add(food);
        }

        public void OrderDrink(IDrink drink)
        {
            drinksCollection.Add(drink);
        }

        public decimal GetBill()
        {
            var totalPrice = foodCollection.Sum(x => x.Price) + drinksCollection.Sum(x => x.Price);

            return totalPrice + Price;
        }

        public void Clear()
        {
            this.foodCollection.Clear();
            this.drinksCollection.Clear();

            this.numberOfPeople = 0;
        }

        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Table: {TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Capacity: {this.Capacity}");
            sb.AppendLine($"Price per Person: {this.PricePerPerson}");

            return sb.ToString().Trim();
        }
    }
}
