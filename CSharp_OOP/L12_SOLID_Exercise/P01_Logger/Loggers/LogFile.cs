using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace P01_Logger.Loggers
{
    public class LogFile : ILogFile
    {
        private const string FilePath = "../../../log.txt";

        public int Size => File.ReadAllText(FilePath).Where(s => char.IsLetter(s)).Sum(s => s);

        public void Write(string content)
        {
            File.AppendAllText(FilePath, content);
        }
    }
}
