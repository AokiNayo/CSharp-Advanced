using System;
using System.Collections.Generic;
using System.Text;
using Logger.Models.Enumerators;

namespace Logger.Models.Contracts
{
    public interface IAppender
    {
        public ILayout Layout { get; }
        public Level Level { get; }

        public void Append(IError error);
    }
}
