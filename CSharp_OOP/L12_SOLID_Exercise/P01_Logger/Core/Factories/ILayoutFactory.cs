using System;
using System.Collections.Generic;
using System.Text;

namespace P01_Logger.Core.Factories
{
    public interface ILayoutFactory
    {
        ILayout CreateLayout(string type);
    }
}
