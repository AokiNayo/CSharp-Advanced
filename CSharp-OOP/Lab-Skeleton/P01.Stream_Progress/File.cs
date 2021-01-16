﻿namespace P01.Stream_Progress
{
    public class File : BaseClass
    {
        private string name;

        public File(string name, int length, int bytesSent)
            : base(bytesSent, length)
        {
            this.name = name;
        }

    }
}
