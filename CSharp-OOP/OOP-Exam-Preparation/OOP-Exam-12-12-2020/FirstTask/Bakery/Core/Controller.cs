using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Enums;
using Bakery.Utilities.Messages;


namespace Bakery.Core
{
    public class Controller : IController
    {
        private List<ITable> tables;
        private List<IBakedFood> bakedFood;
        private List<IDrink> drinks;

        public Controller()
        {
            this.tables = new List<ITable>();
            this.bakedFood = new List<IBakedFood>();
            this.drinks = new List<IDrink>();

        }

        public ICollection<ITable> TableCollection => this.tables;
        public ICollection<IBakedFood> BakedFoodCollection => this.bakedFood;
        public ICollection<IDrink> DrinksCollection => this.drinks;

        public decimal TotalIncome { get; private set; }
        public string AddFood(string type, string name, decimal price)
        {
            Enum.TryParse(type, out BakedFoodType currentType);

            IBakedFood currentFood = currentType switch
            {
                BakedFoodType.Bread => new Bread(name, price),
                BakedFoodType.Cake => new Cake(name, price),
            };

            //IBakedFood currentFood = null;

            //if (type == "Bread")
            //{
            //    currentFood = new Bread(name, price);
            //}
            //else if (type == "Cake")
            //{
            //    currentFood = new Cake(name, price);
            //}

            this.BakedFoodCollection.Add(currentFood);

            return String.Format(OutputMessages.FoodAdded, name, currentFood.GetType().Name); // TODO : CHECK THIS OUTPUT MESSAGE!
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            Enum.TryParse(type, out DrinkType currentType);

            IDrink currentDrink = currentType switch
            {
                DrinkType.Tea => new Tea(name, portion, brand),
                DrinkType.Water => new Water(name, portion, brand),
            };

            //IDrink currentDrink = null;

            //if (type == "Tea")
            //{
            //    currentDrink = new Tea(name, portion, brand);
            //}
            //else if (type == "Water")
            //{
            //    currentDrink = new Water(name, portion, brand);
            //}
            if (currentDrink != null)
            {
                this.DrinksCollection.Add(currentDrink);

                return String.Format(OutputMessages.DrinkAdded, name, brand); // TODO : CHECK THIS OUTPUT MESSAGE!
            }

            return "FALSE";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            Enum.TryParse(type, out TableType currentType);

            ITable currentTable = currentType switch
            {
                TableType.InsideTable => new InsideTable(tableNumber, capacity),
                TableType.OutsideTable => new OutsideTable(tableNumber, capacity),
            };

            //ITable currentTable = null;

            //if (type == "OutsideTable")
            //{
            //    currentTable = new OutsideTable(tableNumber, capacity);
            //}
            //else if (type == "InsideTable")
            //{
            //    currentTable = new InsideTable(tableNumber, capacity);
            //}
            if (currentTable != null)
            {
                this.TableCollection.Add(currentTable);

                return String.Format(OutputMessages.TableAdded, tableNumber); // TODO : CHECK THIS OUTPUT MESSAGE!
            }

            return "FALSE";

        }

        public string ReserveTable(int numberOfPeople)
        {
            var freeTable = this.TableCollection.FirstOrDefault(x => x.IsReserved == false && x.Capacity >= numberOfPeople);

            if (freeTable == null)
            {
                return String.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
            }

            freeTable.Reserve(numberOfPeople);
            return String.Format(OutputMessages.TableReserved, freeTable.TableNumber, numberOfPeople);

        }

        public string OrderFood(int tableNumber, string foodName)
        {
            var tableByNumber = this.TableCollection.FirstOrDefault(x => x.TableNumber == tableNumber);

            if (tableByNumber == null)
            {
                return String.Format(OutputMessages.WrongTableNumber, tableNumber);

            }

            var currentFood = this.BakedFoodCollection.FirstOrDefault(x => x.Name == foodName);

            if (currentFood == null)
            {
                return String.Format(OutputMessages.NonExistentFood, foodName);
            }

            tableByNumber.OrderFood(currentFood);

            return String.Format(OutputMessages.FoodOrderSuccessful, tableNumber, foodName);

        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            var tableByNumber = this.TableCollection.FirstOrDefault(x => x.TableNumber == tableNumber);

            if (tableByNumber == null)
            {
                return String.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            var currentDrink = this.DrinksCollection.FirstOrDefault(x => x.Name == drinkName && x.Brand == drinkBrand);

            if (currentDrink == null)
            {
                return String.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);
            }

            tableByNumber.OrderDrink(currentDrink);

            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}"; // CHECK!!!
        }

        public string LeaveTable(int tableNumber)
        {
            var tableByNumber = this.TableCollection.FirstOrDefault(x => x.TableNumber == tableNumber);

            if (tableByNumber == null)
            {
                throw new ArgumentException(OutputMessages.WrongTableNumber);
            }

            var currentBill = tableByNumber.GetBill();
            this.TotalIncome += currentBill;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {tableNumber}");
            sb.AppendLine($"Bill: {currentBill:f2}");

            tableByNumber.Clear();

            return sb.ToString().Trim();
        }

        public string GetFreeTablesInfo()
        {
            var freeTables = TableCollection.Where(x => x.IsReserved == false);

            if (freeTables == null)
            {
                throw new ArgumentException(OutputMessages.WrongTableNumber);
            }

            StringBuilder sb = new StringBuilder();

            foreach (var freeTable in freeTables)
            {
                sb.AppendLine(freeTable.GetFreeTableInfo());
            }

            return sb.ToString().Trim();
        }

        public string GetTotalIncome()
        {
            return String.Format(OutputMessages.TotalIncome, this.TotalIncome);
        }
    }
}
