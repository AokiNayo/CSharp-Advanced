using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class SpecialisedSoldier : ISpecialisedSoldier
    {
        public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps)
        {
            ID = id;
            Firstname = firstName;
            Lastname = lastName;
            Salary = salary;
            Corps = corps;
        }
        public string Corps { get; private set; }

        public decimal Salary { get; private set; }

        public int ID { get; private set; }

        public string Firstname { get; private set; }

        public string Lastname { get; private set; }
    }
}
