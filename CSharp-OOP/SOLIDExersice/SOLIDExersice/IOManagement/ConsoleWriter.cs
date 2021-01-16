using System;
using System.Collections.Generic;
using System.Text;
using Logger.IOManagement.Contracts;

namespace Logger.IOManagement
{
    class ConsoleWriter : IWriter
    {
        public void Write(string text)
        {
            Console.Write(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
