using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Christmas
{
    public class Bag
    {
        List<Present> data;

        public Bag(string color, int capacity)
        {
            Color = color;
            Capacity = capacity;
            data = new List<Present>();
        }

        public string Color { get; set; }
        public int Capacity { get; set; }
        public int Count
        {
            get
            {
                return data.Count;
            }
        }

        public void Add(Present present)
        {
            if (data.Count < Capacity)
            {
                data.Add(present);
            }
        }
        public bool Remove(string name)
        {
            return data.Remove(data.FirstOrDefault(x => x.Name == name));
        }

        public Present GetHeaviestPresent()
        {
            return data.OrderByDescending(x => x.Weight).FirstOrDefault();
        }

        public Present GetPresent(string name)
        {
            return data.FirstOrDefault(x => x.Name == name);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Color} bag contains:");

            foreach (var item in data)
            {
                sb.AppendLine($"{item}");
            }
            return sb.ToString().Trim();
        }
    }
}
