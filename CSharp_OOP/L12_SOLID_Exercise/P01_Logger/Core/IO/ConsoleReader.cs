using System;
using System.Collections.Generic;
using System.Text;

namespace P01_Logger.Core.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
