using System;
using System.Collections.Generic;
using System.Text;

namespace P01_Logger
{
    class SimpleLayout : ILayout
    {
        public string Template => "{0} - {1} - {2}";
    }
}
