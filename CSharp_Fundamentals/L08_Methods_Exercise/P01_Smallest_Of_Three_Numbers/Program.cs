using System;

namespace _01_Smallest_Of_Three_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {

            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());

            PrintSmallestNum(firstNum, secondNum, thirdNum);

        }

        private static void PrintSmallestNum(int firstNum, int secondNum, int thirdNum)
        {
            int smallestNum = firstNum;

            if (secondNum < firstNum)
            {
                smallestNum = secondNum;
            }
            if (thirdNum < firstNum && thirdNum < secondNum)
            {
                smallestNum = thirdNum;
            }

            Console.WriteLine(smallestNum);
        }

    }
}
