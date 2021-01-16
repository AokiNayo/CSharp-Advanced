using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony.Exeptions
{
    public class InvalidNumberExeption : Exception
    {
        private const string INVALID_NUMBER_EXEPTION = "Invalid number!";

        public InvalidNumberExeption() :
            base(INVALID_NUMBER_EXEPTION)
        {

        }
    }
}
