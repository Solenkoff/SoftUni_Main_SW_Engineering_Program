using System;

namespace _02_Sum_Digits
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();

            int sumOfDigits = 0;

            for (int i = 0; i < input.Length; i++)
            {
                //int currentNumber = (int)Char.GetNumericValue(input[i]);
                int currentNumber = int.Parse(input[i].ToString());
                sumOfDigits += currentNumber;
            }
            Console.WriteLine(sumOfDigits);

        }
    }
}
