using System;

namespace _01_Sort_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {

            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            int highNum = 0;
            int midNum = 0;
            int lowNum = 0;

            if (num1 > num2 && num1 > num3)
            {
                if (num2 > num3)
                {
                    highNum = num1;
                    midNum = num2;
                    lowNum = num3;
                }
                else
                {
                    highNum = num1;
                    midNum = num3;
                    lowNum = num2;
                }
            }
            else if (num2 > num1 && num2 > num3)
            {
                if (num1 > num3)
                {
                    highNum = num2;
                    midNum = num1;
                    lowNum = num3;
                }
                else
                {
                    highNum = num2;
                    midNum = num3;
                    lowNum = num1;
                }
            }
            else if (num3 > num1 && num3 > num2)
            {
                if (num1 > num2)
                {
                    highNum = num3;
                    midNum = num1;
                    lowNum = num2;
                }
                else
                {
                    highNum = num3;
                    midNum = num2;
                    lowNum = num1;
                }
            }
            Console.WriteLine(highNum);
            Console.WriteLine(midNum);
            Console.WriteLine(lowNum);

        }
    }
}
