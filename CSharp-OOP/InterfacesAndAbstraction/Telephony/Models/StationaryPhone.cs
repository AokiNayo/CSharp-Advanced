using System;
using System.Collections.Generic;
using System.Text;
using Telephony.Models;

namespace Telephony
{
    public class StationaryPhone : Phone
    {

        public override string MakeCall(string number)
        {
            return $"Dialing... {base.MakeCall(number)}";

        }
    }
}
