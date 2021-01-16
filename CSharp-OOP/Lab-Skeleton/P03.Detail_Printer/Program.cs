using System;
using System.Collections.Generic;
using P03.Detail_Printer;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            Worker worker;
            List<string> documents = new List<string>() { "First Document", "Second Document", "Third Document" };

            worker = new Employee("Nayo");

            worker.PrintEmployee();

            worker = new Manager("AokiNayo", documents);

            worker.PrintEmployee();
        }
    }
}
