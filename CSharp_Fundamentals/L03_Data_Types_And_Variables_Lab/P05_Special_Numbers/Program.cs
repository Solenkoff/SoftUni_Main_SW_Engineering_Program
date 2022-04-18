using System;

namespace _05_Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {

            int nNumbers = int.Parse(Console.ReadLine());

            for (int i = 1; i <= nNumbers; i++)
            {
                int number = i;
                int iDigitsSum = 0;
                while (number > 0)
                {
                    iDigitsSum += number % 10;
                    number /= 10;
                }
                if (iDigitsSum == 5 || iDigitsSum == 7 || iDigitsSum == 11)
                {
                    Console.WriteLine($"{i} -> True");
                }
                else
                {
                    Console.WriteLine($"{i} -> False");
                }
            }

        }
    }
}
