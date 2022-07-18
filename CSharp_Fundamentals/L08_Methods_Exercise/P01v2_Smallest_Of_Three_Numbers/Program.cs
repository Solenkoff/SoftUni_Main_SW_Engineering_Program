using System;

namespace _01v2_Smallest_Of_Three_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {

            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());

            Console.WriteLine(PrintSmallestNum(firstNum, secondNum, thirdNum));

        }

        static int PrintSmallestNum(int firstNum, int secondNum, int thirdNum)
        {
            int smallestNum = Math.Min(firstNum, Math.Min(secondNum, thirdNum));
            return smallestNum;
        }

    }
}
