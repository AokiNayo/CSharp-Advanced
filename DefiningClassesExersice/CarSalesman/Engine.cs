using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    public class Engine
    {
        public Engine()
        {
            Model = "n/a";
            Power = "n/a";
            Displacement = "n/a";
            Efficiency = "n/a";

            
        }

        public Engine(string model, string power) : this()
        {
            Model = model;
            Power = power;
        }

        public Engine(string model, string power, string displacement) : this()
        {
            Model = model;
            Power = power;
            Displacement = displacement;
        }

        public Engine(string model, string power, string displacement, string efficiency)
        {
            Model = model;
            Power = power;
            Displacement = displacement;
            Efficiency = efficiency;
        }

        public string Model { get; set; }
        public string Power { get; set; }
        public string Displacement { get; set; }
        public string Efficiency { get; set; }

    }
}
