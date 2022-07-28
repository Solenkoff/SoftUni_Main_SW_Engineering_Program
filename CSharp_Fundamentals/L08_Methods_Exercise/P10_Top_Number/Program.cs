using System;

namespace _10_Top_Number
{
    class Program
    {
        static void Main(string[] args)
        {

            int number = int.Parse(Console.ReadLine());

            TopNumbers(number);

        }


        private static void TopNumbers(int number)
        {
            for (int i = 17; i <= number; i++)
            {
                if (SumOfDigits(i) % 8 == 0 && HoldsOddDigits(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        private static bool HoldsOddDigits(int i)
        {
            bool holdsOddDigits = false;

            while (i > 0)
            {
                int lastDigit = 0;
                lastDigit = i % 10;
                if (lastDigit % 2 == 1)
                {
                    holdsOddDigits = true;
                }
                i /= 10;
            }

            return holdsOddDigits;
        }

        private static int SumOfDigits(int i)
        {
            int sum = 0;
            while (i > 0)
            {
                int lastDigit = 0;
                lastDigit = i % 10;
                sum += lastDigit;
                i /= 10;
            }

            return sum;
        }
    }
}
