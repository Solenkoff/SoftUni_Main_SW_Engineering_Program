using System;

namespace _02_English_Name_Of_The_Last_Digit
{
    class Program
    {
        static void Main(string[] args)
        {

            int number = int.Parse(Console.ReadLine());

            int lastDigit = number % 10;
            string digitInWords = string.Empty;

            switch (lastDigit)
            {
                case 0:
                    digitInWords = "zero";
                    break;
                case 1:
                    digitInWords = "one";
                    break;
                case 2:
                    digitInWords = "two";
                    break;
                case 3:
                    digitInWords = "three";
                    break;
                case 4:
                    digitInWords = "four";
                    break;
                case 5:
                    digitInWords = "five";
                    break;
                case 6:
                    digitInWords = "six";
                    break;
                case 7:
                    digitInWords = "seven";
                    break;
                case 8:
                    digitInWords = "eight";
                    break;
                case 9:
                    digitInWords = "nine";
                    break;
            }
            Console.WriteLine(digitInWords);

        }
    }
}
