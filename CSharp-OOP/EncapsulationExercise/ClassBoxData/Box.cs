using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get
            {
                return this.length;
            }
            private set
            {
                try
                {
                    if (value <= 0)
                    {
                        throw new ArgumentException($"Length cannot be zero or negative.");
                    }
                    this.length = value;
                }
                catch (Exception msg)
                {
                    Console.WriteLine(msg.Message);
                    Environment.Exit(0);
                }
            }
        }
        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                try
                {
                    if (value <= 0)
                    {
                        throw new ArgumentException($"Width cannot be zero or negative.");
                    }
                    this.width = value;
                }
                catch (Exception msg)
                {
                    Console.WriteLine(msg.Message);
                    Environment.Exit(0);
                }
            }
        }
        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                try
                {
                    if (value <= 0)
                    {
                        throw new ArgumentException($"Height cannot be zero or negative.");
                    }

                    this.height = value;
                }
                catch (Exception msg)
                {
                    Console.WriteLine(msg.Message);
                    Environment.Exit(0);
                }
            }
        }

        public override string ToString()
        {
            double volume = length * width * height;
            double lateralSurfaceArea = 2 * length * height + 2 * width * height;
            double surfaceArea = (2 * length * width) + (2 * length * height) + 2 * (width * height);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Surface Area - {surfaceArea:f2}");
            sb.AppendLine($"Lateral Surface Area - {lateralSurfaceArea:f2}");
            sb.AppendLine($"Volume - {volume:f2}");

            return sb.ToString().Trim();
        }


    }
}
