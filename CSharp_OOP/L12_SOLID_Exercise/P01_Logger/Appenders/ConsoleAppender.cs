﻿using P01_Logger.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_Logger.Appenders
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            : base(layout)
        {
        }

        public override void Append(string date, ReportLevel reportLevel, string message)
        {
            if(!this.CanAppend(reportLevel))
            {
                return;
            }

            this.MessagesCount += 1;

            string content = string.Format(this.layout.Template, date, reportLevel, message);

            Console.WriteLine(content);
        }
    }
}
