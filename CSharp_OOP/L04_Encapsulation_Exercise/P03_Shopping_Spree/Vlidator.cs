using System;
using System.Collections.Generic;
using System.Text;

namespace P02_Shopping_Spree
{
    public static class Validator
    {

        public static void ThrowIfStringIsNullOrEmpty(string str, string exceptionMessage)
        {
            if(string.IsNullOrWhiteSpace(str))
            {
                throw new ArgumentException(exceptionMessage);
            }
        }


        public static void ThrowIfNumberIsNegative(decimal number, string exceptionMassege)
        {
            if (number < 0)
            {
                throw new ArgumentException(exceptionMassege);
            }
        }
        
    }
}
