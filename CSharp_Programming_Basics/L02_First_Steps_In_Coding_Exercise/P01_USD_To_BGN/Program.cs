using System;

namespace _01_USD_To_BGN
{
    class Program
    {
        static void Main(string[] args)
        {
            double USD = double.Parse(Console.ReadLine());
            double converterUsdForBg = 1.79549;
            double bgn = USD * converterUsdForBg;

            Console.WriteLine(bgn);
        }
    }
}
