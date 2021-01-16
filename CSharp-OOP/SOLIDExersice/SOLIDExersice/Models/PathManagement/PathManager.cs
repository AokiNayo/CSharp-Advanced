using System;
using System.IO;
using Logger.Models.Contracts;

namespace Logger.Models.Layouts.PathManagement
{
    class PathManager : IPathManager
    {
        private readonly string currentPath;
        private readonly string folderName;
        private readonly string fileName;

        public PathManager()
        {
            this.currentPath = this.GetCurrentPath();

        }

        public PathManager(string folderName, string fileName) 
            : this()
        {
            this.folderName = folderName;
            this.fileName = fileName;
        }

        public string CurrentDirectoryPath
            => Path.Combine(this.currentPath, this.folderName);

        public string CurrentFilePath 
            => Path.Combine(this.CurrentDirectoryPath, this.fileName);
        public string GetCurrentPath()
        {
            return Directory.GetCurrentDirectory();
        }

        public void EnsureDirectoryAndFileExists()
        {
            if (!Directory.Exists(this.CurrentDirectoryPath))
            {
                Directory.CreateDirectory(this.CurrentDirectoryPath);
            }

            File.AppendAllText(this.CurrentFilePath, String.Empty);
        }
    }
}
