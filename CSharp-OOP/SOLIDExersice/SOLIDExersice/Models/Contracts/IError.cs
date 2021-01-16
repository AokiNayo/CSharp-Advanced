
using System;
using Logger.Models.Enumerators;

namespace Logger.Models.Contracts
{
    public interface IError
    {
        public DateTime DateTime { get; }

        public string Message { get; }

        public Level Level { get; }
    }
}
