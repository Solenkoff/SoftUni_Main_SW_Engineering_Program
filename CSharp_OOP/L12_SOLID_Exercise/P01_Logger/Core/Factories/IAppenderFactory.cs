using P01_Logger.Appenders;
using P01_Logger.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_Logger.Core.Factories
{
    public interface IAppenderFactory
    {
        IAppender CreateAppender(string type, ILayout layout, ReportLevel reportLevel);
    }
}
