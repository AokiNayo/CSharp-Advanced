﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Interfaces
{
    public interface IRepairs
    {
        public string PartName { get; }
        public int HoursWorked { get; }
    }
}