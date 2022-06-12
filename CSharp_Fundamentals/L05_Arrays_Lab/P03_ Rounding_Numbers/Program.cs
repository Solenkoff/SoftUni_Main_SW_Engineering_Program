using System;

namespace _03__Rounding_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {

            double[] arr = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"{arr[i]} => {Math.Round(arr[i], MidpointRounding.AwayFromZero)}");
            }

        }
    }
}
