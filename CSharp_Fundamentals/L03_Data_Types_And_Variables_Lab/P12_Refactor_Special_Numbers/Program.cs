using System;

namespace _12_Refactor_Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {

            int nNumbers = int.Parse(Console.ReadLine());

            for (int i = 1; i <= nNumbers; i++)
            {
                int iDigitsSum = 0;
                int number = i;
                while (number > 0)
                {
                    iDigitsSum += number % 10;
                    number /= 10;
                }
                bool isSpecialNum = (iDigitsSum == 5) || (iDigitsSum == 7) || (iDigitsSum == 11);
                Console.WriteLine($"{i} -> {isSpecialNum}");
            }

        }
    }
}
