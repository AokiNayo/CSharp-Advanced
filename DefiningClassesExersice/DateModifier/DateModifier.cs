using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace DateModifierExersice
{
    public class DateModifier
    {
        public int Difference { get; set; }

        public int CalculateDifference(string firstDate, string secondDate)
        {
            DateTime startDate = DateTime.Parse(firstDate);
            DateTime endDate = DateTime.Parse(secondDate);

            var totalDays = (int)Math.Abs((startDate - endDate).TotalDays);
            return totalDays;

        }
    }
}
