using System;

namespace P03_Recursive_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int nInput = int.Parse(Console.ReadLine());

            if (nInput <= 1)
            {
                Console.WriteLine(1);
            }

            else
            {
                double addPhi = (1 + Math.Sqrt(5)) / 2;
                double subtractPhi = (1 - Math.Sqrt(5)) / 2;

                double fibonacci = (Math.Pow(addPhi, nInput) - Math.Pow((-subtractPhi), nInput)) / Math.Sqrt(5);

                long roundedFib = (long)Math.Round(fibonacci);

                Console.WriteLine(roundedFib);
            }
        }
    }
}
