namespace P02_Big_Factorial
{
    using System;
    using System.Numerics;

    class Program
    {
        static void Main(string[] args)
        {

            BigInteger factorial = 1;
            int n = int.Parse(Console.ReadLine());

            for (int i = 2; i <= n; i++)
            {
                factorial *= i;
            }

            Console.WriteLine(factorial);

        }
    }
}
