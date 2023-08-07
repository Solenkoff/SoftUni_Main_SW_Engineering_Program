namespace P01_Square_Root
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class InvalidNumException : Exception
    {
        public InvalidNumException(string message)
            :base(message)
        {
           
        }
    }
}
