using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telephony.Exeptions;
using Telephony.Models;

namespace Telephony
{
    public class Smartphone : Phone, IBrowseable
    {

        public string Browse(string site)
        {
            if (site.Any(x => char.IsDigit(x)))
            {
                throw new InvalidURLExeption();
            }
            else
            {
                return $"Browsing: {site}!";
            }
        }

        public override string MakeCall(string number)
        {
            return $"Calling... {base.MakeCall(number)}";
        }
    }
}
