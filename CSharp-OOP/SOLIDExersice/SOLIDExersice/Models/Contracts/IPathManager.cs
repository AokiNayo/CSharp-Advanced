using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Models.Contracts
{
    public interface IPathManager
    {
        public string CurrentDirectoryPath { get; }

        public string CurrentFilePath { get; }

        public string GetCurrentPath();

        public void EnsureDirectoryAndFileExists();
    }
}
