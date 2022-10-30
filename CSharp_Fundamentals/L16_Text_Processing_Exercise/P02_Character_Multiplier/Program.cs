using System;

namespace _02_Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] input = Console.ReadLine()
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string stringOne = input[0];
            string stringTwo = input[1];
            string longString = stringOne;
            string shortString = stringTwo;

            if (stringOne.Length < stringTwo.Length)
            {
                longString = stringTwo;
                shortString = stringOne;
            }

            int total = SumOfMultipliedCharacters(longString, shortString);

            Console.WriteLine(total);

        }

        private static int SumOfMultipliedCharacters(string longString, string shortString)
        {
            int sum = 0;

            for (int i = 0; i < shortString.Length; i++)
            {
                int multiplication = shortString[i] * longString[i];
                sum += multiplication;
            }
            for (int i = shortString.Length; i < longString.Length; i++)
            {
                sum += longString[i];
            }

            return sum;
        }

    }
}
