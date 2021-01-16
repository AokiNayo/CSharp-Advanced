using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class Soldier : ISoldier
    {
        public Soldier(int id, string firstName, string lastName)
        {
            ID = id;
            Firstname = firstName;
            Lastname = lastName;
        }
        public int ID { get; private set; }

        public string Firstname { get; private set; }

        public string Lastname { get; private set; }
    }
}
