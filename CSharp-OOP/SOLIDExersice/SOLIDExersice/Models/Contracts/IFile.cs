using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Models.Contracts
{
    public interface IFile
    {
        public string Path { get; }

        public long Size { get; }

        public string Write(ILayout layout, IError error);
    }
}
