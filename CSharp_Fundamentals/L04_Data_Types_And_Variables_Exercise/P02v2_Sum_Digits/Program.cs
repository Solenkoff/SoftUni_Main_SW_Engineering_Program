using System;

namespace _02v2_Sum_Digits
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int inputNumber = int.Parse(Console.ReadLine());

            int sumOfDigits = 0;
            int number = inputNumber;
            while (number > 0)
            {
                sumOfDigits += number % 10;
                number /= 10;
            }
            Console.WriteLine(sumOfDigits);

        }
    }
}
