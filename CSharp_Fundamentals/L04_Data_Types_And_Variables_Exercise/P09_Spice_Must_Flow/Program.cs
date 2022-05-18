using System;

namespace _09_Spice_Must_Flow_
{
    class Program
    {
        static void Main(string[] args)
        {

            int startYield = int.Parse(Console.ReadLine());

            int totalYield = 0;
            int expectedYield = startYield;

            int days = 0;

            while (expectedYield >= 100)
            {
                totalYield += (expectedYield - 26);
                expectedYield -= 10;
                days++;
            }
            if (days != 0)
            {
                totalYield -= 26;
            }

            Console.WriteLine(days);
            Console.WriteLine(totalYield);

        }
    }
}
