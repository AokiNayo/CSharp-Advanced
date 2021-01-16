using System;
using System.Collections.Generic;
using System.Text;

namespace P03.Detail_Printer
{
    public class Worker
    {
        public Worker(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public virtual void PrintEmployee()
        {
            Console.WriteLine(this.Name);
        }
    }
}
