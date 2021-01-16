using System;
using System.Collections.Generic;
using System.Text;
using Logger.IOManagement.Contracts;

namespace Logger.IOManagement
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
