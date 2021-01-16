using System;
using Logger.IOManagement;
using Logger.IOManagement.Contracts;
using Logger.Models.Contracts;
using Logger.Models.Enumerators;

namespace Logger.Models.Appenders
{
    public class FileAppender : Appender
    {
        private readonly IWriter writer;
        public FileAppender(ILayout layout, Level level, IFile file)
            : base(layout, level)
        {
            this.File = file;

            this.writer = new FileWriter(this.File.Path);
        }

        public IFile File { get; }

        public override void Append(IError error)
        {
            string forrmattedMessage = this.File.Write(this.Layout, error);

            this.writer.WriteLine(forrmattedMessage);
            this.messagesAppend++;
        }

        public override string ToString()
        {
            return base.ToString() + $", File size {this.File.Size}";
        }
    }
}
