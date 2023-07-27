using System;
using System.Collections.Generic;
using System.Text;

namespace FootbalTeamGenerator
{
    public static class Validator
    {
        public static void ThrowIfStringIsNullOrWhiteSpace(string str, string exceptionMessage)
        {
            if(String.IsNullOrWhiteSpace(str))
            {
                throw new ArgumentException(exceptionMessage);
            }
        }


        public static void ThrowIfNumberIsNotInRange(int number, int min, int max, string exceptionMessage)
        {
            if(number < min || number > max)
            {
                throw new ArgumentException(exceptionMessage);
            }
        }
    }
}
