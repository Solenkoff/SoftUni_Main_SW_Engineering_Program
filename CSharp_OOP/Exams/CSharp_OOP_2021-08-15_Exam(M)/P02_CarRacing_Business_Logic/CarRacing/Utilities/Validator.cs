namespace CarRacing.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class Validator
    {
        public static void ThrowIfStringIsNullOrWhiteSpace(string value, string message)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(message);
            }
        }

        //public static void ThrowIfValueIsNegative(string value, string message)
        //{
        //    if (string.IsNullOrWhiteSpace(value))
        //    {
        //        throw new ArgumentException(message);
        //    }
        //}

    }
}
