using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    class Mission : IMission
    {
        public Mission(string codeName, string state)
        {
            CodeName = codeName;
            State = state;
        }
        public string CodeName { get; private set; }
        public string State { get; private set; }

        public void CompleteMission()
        {
            State = "finished";
        }

        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {State}";
        }
    }
}
