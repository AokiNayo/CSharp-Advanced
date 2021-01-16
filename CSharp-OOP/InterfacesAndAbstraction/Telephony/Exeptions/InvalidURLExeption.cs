using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony.Exeptions
{
    public class InvalidURLExeption : Exception
    {
        private const string INVALID_URL_EXEPTION = "Invalid URL!";

        public InvalidURLExeption() :
            base(INVALID_URL_EXEPTION)
        {

        }
    }
}
