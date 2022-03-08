using System;

namespace _02_Equal_Sums_Even_Odd_Position
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            for (int i = firstNum; i <= secondNum; i++)
            {
                string currNum = i.ToString();
                int evenSum = 0;
                int oddSum = 0;
                for (int j = 0; j < currNum.Length; j++)
                {
                    int currentDigit = int.Parse(currNum[j].ToString());
                    if (j % 2 == 0)
                    {
                        evenSum += currentDigit;
                    }
                    else
                    {
                        oddSum += currentDigit;
                    }
                }
                if (oddSum == evenSum)
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}
