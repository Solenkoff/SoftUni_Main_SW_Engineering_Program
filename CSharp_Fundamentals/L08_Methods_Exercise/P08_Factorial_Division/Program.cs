using System;

namespace _08_Factorial_Division
{
    class Program
    {
        static void Main(string[] args)
        {

            int firstInt = int.Parse(Console.ReadLine());
            int secondInt = int.Parse(Console.ReadLine());

            double result = 0d;
            result = CalculateFactorial(firstInt) / CalculateFactorial(secondInt);

            Console.WriteLine($"{result:f2}");

        }

        private static double CalculateFactorial(int input)
        {
            double result = 1;
            for (int i = 1; i <= input; i++)
            {
                result *= i;
            }

            return result;
        }

    }
}
