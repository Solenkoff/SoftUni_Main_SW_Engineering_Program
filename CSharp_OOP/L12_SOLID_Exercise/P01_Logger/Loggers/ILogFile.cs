using System;
using System.Collections.Generic;
using System.Text;

namespace P01_Logger.Loggers
{
    public interface ILogFile
    {
        int Size { get; }
        void Write(string content);
    }
}
