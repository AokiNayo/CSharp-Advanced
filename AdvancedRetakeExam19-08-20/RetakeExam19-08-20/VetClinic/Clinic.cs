using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        public Clinic(int capacity)
        {
            this.Capacity = capacity;
            this.data = new List<Pet>();
        }
        private List<Pet> data;
        public int Capacity { get; set; }
        public int Count
        {
            get
            {
                return this.data.Count;
            }
        }

        public void Add(Pet pet)
        {
            if (this.Count < this.Capacity)
            {
                this.data.Add(pet);
            }
        }
        public bool Remove(string name)
            => data.Remove(data.FirstOrDefault(p => p.Name == name));

        public Pet GetPet(string name, string owner)
            => data.FirstOrDefault(p => p.Name == name && p.Owner == owner);
        public Pet GetOldestPet()
            => data.OrderByDescending(p => p.Age).FirstOrDefault();
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("The clinic has the following patients:");
            foreach (var item in this.data)
            {
                //sb.AppendLine($"Pet {item.Name} with owner: {item.Owner}"); // -Това работи - 100 / 100
                sb.AppendLine(item.ToString()); // -Това не работи. 91 / 100
            }
            return sb.ToString().TrimEnd();
        }
    }
}
