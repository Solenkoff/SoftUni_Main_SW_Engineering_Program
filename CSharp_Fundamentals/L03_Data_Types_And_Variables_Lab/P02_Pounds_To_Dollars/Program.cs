using System;

namespace _02_Pounds_To_Dollars
{
    class Program
    {
        static void Main(string[] args)
        {

            decimal britPounds = decimal.Parse(Console.ReadLine());
            decimal usd = britPounds * 1.31M;
            Console.WriteLine($"{usd:f3}");

        }
    }
}
