using P01_Logger.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_Logger.Appenders
{
    public interface IAppender
    {

        ReportLevel ReportLevel { get; set; }
        void Append(string date, ReportLevel reportLevel, string message);

    }
}
