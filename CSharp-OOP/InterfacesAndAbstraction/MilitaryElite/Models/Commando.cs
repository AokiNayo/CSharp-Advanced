using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class Commando : ICommando
    {
        public Commando(int id, string firstName, string lastName, decimal salary, string corps, ICollection<IMission> missions)
        {
            ID = id;
            Firstname = firstName;
            Lastname = lastName;
            Salary = salary;
            Corps = corps;
            Missions = missions;
        }
        public string Corps { get; private set; }

        public decimal Salary { get; private set; }

        public int ID { get; private set; }

        public string Firstname { get; private set; }

        public string Lastname { get; private set; }

        public ICollection<IMission> Missions { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Name: {Firstname} {Lastname} Id: {ID} Salary: {Salary:f2}");
            sb.AppendLine($"Corps: {Corps}");
            sb.AppendLine($"Missions:");

            foreach (var item in Missions)
            {
                sb.AppendLine("  " + item.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
