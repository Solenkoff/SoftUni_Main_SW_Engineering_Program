using System;
using System.Collections.Generic;
using System.Text;

namespace P01_Logger.Layouts
{
    public class JsonLayout : ILayout
    {
        public string Template
        {
            get
            {

                return @"""log"": {{
  ""date"": ""{0}"",
  ""level"": ""{1}"",
  ""message"": ""{2}""
}},";

            }
        }
    }
}
