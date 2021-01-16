using System;
using System.Collections.Generic;
using System.Text;
using P03.Detail_Printer;

namespace P03.DetailPrinter
{
    public class Manager : Worker
    {
        public Manager(string name, ICollection<string> documents)
            : base(name)
        {
            this.Documents = new List<string>(documents);
        }

        public IReadOnlyCollection<string> Documents { get; set; }

        public override void PrintEmployee()
        {
            base.PrintEmployee();
            Console.WriteLine(string.Join(Environment.NewLine, this.Documents));
        }
    }
}
