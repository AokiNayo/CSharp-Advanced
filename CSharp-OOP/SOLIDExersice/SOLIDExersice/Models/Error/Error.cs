﻿using System;
using System.Collections.Generic;
using System.Text;
using Logger.Models.Contracts;
using Logger.Models.Enumerators;

namespace Logger.Models.Error
{
    class Error : IError
    {
        public Error(DateTime dateTime, string message, Level level)
        {
            this.DateTime = dateTime;
            this.Message = message;
            this.Level = level;
        }
        public DateTime DateTime { get; }

        public string Message { get; }

        public Level Level { get; }
    }
}
