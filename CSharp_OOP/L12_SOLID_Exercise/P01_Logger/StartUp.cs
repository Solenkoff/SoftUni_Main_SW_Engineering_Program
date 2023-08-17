

using P01_Logger.Appenders;
using P01_Logger.Core;
using P01_Logger.Core.Factories;
using P01_Logger.Core.IO;
using P01_Logger.Enums;
using P01_Logger.Layouts;
using P01_Logger.Loggers;
using System;
using System.Collections.Generic;

namespace P01_Logger
{
    public class StartUp
    {

        static void Main(string[] args)
        {

            IAppenderFactory appenderFactory = new AppenderFactory();

            ILayoutFactory layoutFactory = new LayoutFactory();

            IReader reader = new FileReader();


            IEngine engine = new Engine(appenderFactory, layoutFactory, reader);

            engine.Run();
        }


    }
}
