using System;

namespace _09_Left_And_Right_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int left = 0;
            int right = 0;
            for (int i = 1; i <= num; i++)
            {
                int number = int.Parse(Console.ReadLine());
                left += number;
            }
            for (int i = 1; i <= num; i++)
            {
                int number = int.Parse(Console.ReadLine());
                right += number;
            }
            if (left == right)
            {
                Console.WriteLine($"Yes, sum = {Math.Abs(left)}");
            }
            else
            {
                double diffrence = left - right;
                Console.WriteLine($"No, diff = {Math.Abs(diffrence)}");
            }
        }
    }
}
