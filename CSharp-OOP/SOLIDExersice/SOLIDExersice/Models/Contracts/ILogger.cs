using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Models.Contracts
{
    public interface ILogger
    {
        IReadOnlyCollection<IAppender> Appenders { get; }
        public void Log(IError error);

    }
}
