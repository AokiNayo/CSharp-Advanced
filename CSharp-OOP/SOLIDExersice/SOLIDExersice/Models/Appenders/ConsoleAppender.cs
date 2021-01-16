using System;

using Logger.Common;
using Logger.IOManagement;
using Logger.IOManagement.Contracts;
using Logger.Models.Enumerators;
using Logger.Models.Contracts;

namespace Logger.Models.Appenders
{
    public class ConsoleAppender : Appender
    {
        private readonly IWriter writer;

        public ConsoleAppender(ILayout layout, Level level)
            :base (layout,level)
        {
            this.writer = new ConsoleWriter();
        }

        public override void Append(IError error)
        {
            string format = this.Layout.Format;

            DateTime dateTime = error.DateTime;
            string message = error.Message;
            Level level = error.Level;

            string formattedString = String.Format(
                format, 
                dateTime.ToString(GlobalConstants.DateTimeFormat),
                level.ToString(), message);

            this.writer.WriteLine(formattedString);
            this.messagesAppend++;
        }
    }
}
