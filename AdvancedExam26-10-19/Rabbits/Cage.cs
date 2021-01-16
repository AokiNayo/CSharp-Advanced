using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rabbits
{
    public class Cage
    {
        private List<Rabbit> data;

        public Cage(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Rabbit>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count
        {
            get
            {
                return this.data.Count;
            }
        }

        public void Add(Rabbit rabbit)
        {
            if (this.Count < this.Capacity)
            {
                this.data.Add(rabbit);
            }
        }
        public bool RemoveRabbit(string name)
        {
            return this.data.Remove(data.FirstOrDefault(x => x.Name == name));
        }
        public void RemoveSpecies(string species)
        {
            this.data.RemoveAll(x => x.Species == species);
        }
        public Rabbit SellRabbit(string name)
        {

            var rabbit = this.data.FirstOrDefault(x => x.Name == name);
            rabbit.Available = false;
            return rabbit;
        }
        public Rabbit[] SellRabbitsBySpecies(string species)
        {
            var rabbits = this.data.Where(x => x.Species == species).ToList();
            rabbits.ForEach(x => x.Available = false);
            return rabbits.ToArray();
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Rabbits available at {Name}:");
            foreach (var item in this.data.Where(x => x.Available == true))
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().Trim();
        }

    }
}