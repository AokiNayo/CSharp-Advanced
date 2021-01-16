using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class Private : IPrivate
    {
        public Private(int id, string firstName, string lastName, decimal salary)
        {
            ID = id;
            Firstname = firstName;
            Lastname = lastName;
            Salary = salary;
        }
        public decimal Salary { get; private set; }

        public int ID { get; private set; }

        public string Firstname { get; private set; }

        public string Lastname { get; private set; }

        public override string ToString()
        {
            return $"Name: {Firstname} {Lastname} Id: {ID} Salary: {Salary:f2}";
        }
    }
}
