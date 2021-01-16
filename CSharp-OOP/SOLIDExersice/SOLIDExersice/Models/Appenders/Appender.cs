using System;
using System.Collections.Generic;
using System.Text;
using Logger.Models.Contracts;
using Logger.Models.Enumerators;

namespace Logger.Models.Appenders
{
    public abstract class Appender : IAppender
    {
        protected int messagesAppend;
        protected Appender(ILayout layout, Level level)
        {
            this.Layout = layout;
            this.Level = level;
        }
        public ILayout Layout { get; }
        public Level Level { get; }
        public abstract void Append(IError error);

        public virtual string ToString()
        {
            return
                $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}," +
                $" Report level: {this.Level.ToString()}, Messages appended: {this.messagesAppend}";
        }
    }
}
