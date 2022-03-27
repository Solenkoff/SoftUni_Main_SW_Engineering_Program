﻿using System;

namespace P06_Strong_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int number = input;

            int currantDigit = 0;
            int factorialSum = 0;

            while (number != 0)
            {
                currantDigit = number % 10;
                number /= 10;

                int factorial = 1;

                for (int i = 1; i <= currantDigit; i++)
                {
                    factorial *= i;
                }

                factorialSum += factorial;
            }
            if (factorialSum == input)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
