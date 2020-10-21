using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarSalesman
{
    public class Car
    {
        public Car()
        {
            Model = "n/a";
            Weight = "n/a";
            Color = "n/a";
        }

        public Car(string model, Engine engine) : this()
        {
            Model = model;
            Engine = engine;
        }

        public Car(string model, Engine engine, string weight) : this()
        {
            Model = model;
            Engine = engine;
            Weight = weight;
        }

        public Car(string model, Engine engine, string weight, string color)
        {
            Model = model;
            Engine = engine;
            Weight = weight;
            Color = color;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public string Weight { get; set; }
        public string Color { get; set; }


        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"{Model}:");
            result.AppendLine($"  {Engine.Model}");
            result.AppendLine($"    Power: {Engine.Power}");
            result.AppendLine($"    Displacement: {Engine.Displacement}");
            result.AppendLine($"    Efficiency: {Engine.Efficiency}");
            result.AppendLine($"  Weight: {Weight}");
            result.AppendLine($"  Color: {Color}");

            return result.ToString();
        }
    }
}
