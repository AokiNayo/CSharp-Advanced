using System;
using System.Collections.Generic;
using System.Text;
using P03.Detail_Printer;

namespace P03.DetailPrinter
{
    public class DetailsPrinter
    {
        private IList<Worker> employees;

        public DetailsPrinter(IList<Worker> employees)
        {
            this.employees = employees;
        }

        public void PrintDetails()
        {
            foreach (Worker employee in this.employees)
            {

                employee.PrintEmployee();
            }
        }

    }
}
