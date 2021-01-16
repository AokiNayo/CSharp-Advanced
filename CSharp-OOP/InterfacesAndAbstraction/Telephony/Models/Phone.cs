using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telephony.Exeptions;

namespace Telephony.Models
{
    public abstract class Phone : ICallable
    {
        public virtual string MakeCall(string number)
        {
            if (!number.All(x => char.IsDigit(x)))
            {
                throw new InvalidNumberExeption();
            }
            return number;
                
        }
    }
}
