using System;

namespace P09_Sum_of_Odd_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int nNumbers = int.Parse(Console.ReadLine());

            int sumOfNumbers = 0;
            for (int i = 1; i <= nNumbers; i++)
            {
                Console.WriteLine("{0}", 2 * i - 1);
                sumOfNumbers += 2 * i - 1;
            }
            Console.WriteLine($"Sum: {sumOfNumbers}");
        }
    }
}
