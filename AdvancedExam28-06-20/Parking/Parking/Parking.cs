using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        public Parking(string type, int capacity)
        {
            data = new List<Car>();
            Type = type;
            Capacity = capacity;
        }

        private List<Car> data;
        public string Type { get; set; }
        public int Capacity { get; set; }
        public int Count
        {
            get
            {
                return data.Count;
            }
        }

        public void Add(Car car)
        {
            if (data.Count < Capacity)
            {
                data.Add(car);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            var car = data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
            return data.Remove(car);
        }
        public Car GetLatestCar()
        {
            if (Count == 0)
            {
                return null;
            }

            var car = data.OrderByDescending(x => x.Year).First();
            return car;
        }
        public Car GetCar(string manufacturer, string model)
        {
            var car = data.FirstOrDefault(x => x.Model == model && x.Manufacturer == manufacturer);
            return car;
        }
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {Type}:");

            foreach (var item in data)
            {
                sb.AppendLine($"{item}");
            }
            return sb.ToString().Trim();
        }
    }
}
