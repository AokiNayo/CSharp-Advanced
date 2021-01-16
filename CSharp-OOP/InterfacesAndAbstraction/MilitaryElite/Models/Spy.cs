using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class Spy : ISpy
    {
        public Spy(int id, string firstName, string lastName, int codeNumber)
        {
            ID = id;
            Firstname = firstName;
            Lastname = lastName;
            CodeNumber = codeNumber;
        }
        public int CodeNumber { get; private set; }

        public int ID { get; private set; }

        public string Firstname { get; private set; }

        public string Lastname { get; private set; }

        public override string ToString()
        {
            return $"Name: {Firstname} {Lastname} Id: {ID}"
                + Environment.NewLine 
                + $"Code Number: {CodeNumber}";
        }
    }
}
