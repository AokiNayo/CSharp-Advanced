using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Interfaces
{
    public interface ISoldier
    {
        public int ID { get;}
        public string Firstname { get; }
        public string Lastname { get; }
    }
}
