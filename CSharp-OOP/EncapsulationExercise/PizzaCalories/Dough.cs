using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private const double caloriesPerGram = 2;
        private const double white = 1.5;
        private const double wholegrain = 1.0;
        private const double crispy = 0.9;
        private const double chewy = 1.1;
        private const double homemade = 1.0;

        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }

        public string FlourType
        {
            get => this.flourType;
            private set
            {
                try
                {
                    if (value.ToLower() == "white" || value.ToLower() == "wholegrain")
                    {
                        this.flourType = value.ToLower();
                    }
                    else
                    {
                        throw new ArgumentException("Invalid type of dough.");
                    }
                }
                catch (ArgumentException msg)
                {
                    Console.WriteLine(msg.Message);
                    Environment.Exit(0);
                }
            }
        }
        public string BakingTechnique
        {
            get => bakingTechnique;
            private set
            {
                try
                {
                    if (value.ToLower() == "crispy" || value.ToLower() == "chewy" || value.ToLower() == "homemade")
                    {
                        this.bakingTechnique = value.ToLower();
                    }
                    else
                    {
                        throw new ArgumentException("Invalid type of dough.");
                    }
                }
                catch (ArgumentException msg)
                {
                    Console.WriteLine(msg.Message);
                    Environment.Exit(0);
                }
            }
        }
        public double Weight
        {
            get => this.weight;
            private set
            {
                try
                {
                    if (value < 1 || value > 200)
                    {
                        throw new ArgumentException("Dough weight should be in the range [1..200].");
                    }
                    this.weight = value;
                }
                catch (ArgumentException msg)
                {
                    Console.WriteLine(msg.Message);
                    Environment.Exit(0);
                }
            }
        }

        public double CalculateCalories()
        {
            double modifier = 0;
            double result = 0;

            if (FlourType == "white")
            {
                if (BakingTechnique == "crispy")
                {
                    modifier = crispy;
                }
                else if (BakingTechnique == "chewy")
                {
                    modifier = chewy;
                }
                else if (BakingTechnique == "homemade")
                {
                    modifier = homemade;
                }

                result = caloriesPerGram * weight * white * modifier;
            }
            else
            {
                if (BakingTechnique == "crispy")
                {
                    modifier = crispy;
                }
                else if (BakingTechnique == "chewy")
                {
                    modifier = chewy;
                }
                else if (BakingTechnique == "homemade")
                {
                    modifier = homemade;
                }
                result = caloriesPerGram * weight * wholegrain * modifier;

            }

            return result;

        }
    }
}
