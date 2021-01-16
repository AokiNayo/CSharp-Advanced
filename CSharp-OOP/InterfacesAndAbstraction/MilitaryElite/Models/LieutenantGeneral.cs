using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MilitaryElite.Models
{
    public class LieutenantGeneral : ILieutenantGeneral
    {
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary, ICollection<IPrivate> privates)
        {
            ID = id;
            Firstname = firstName;
            Lastname = lastName;
            Salary = salary;
            Privates = privates;
        }
        public ICollection<IPrivate> Privates { get; private set; }

        public decimal Salary { get; private set; }

        public int ID { get; private set; }

        public string Firstname { get; private set; }

        public string Lastname { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {Firstname} {Lastname} Id: {ID} Salary: {Salary:f2}");
            sb.AppendLine("Privates:");
            foreach (var item in Privates)
            {
                sb.AppendLine("  " + item.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
