using System;
using System.Linq;

namespace _06_Even_And_Odd_Subtraction
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int sumOdds = 0;
            int sumEvens = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] % 2 == 0)
                {
                    sumEvens += nums[i];
                }
                else
                {
                    sumOdds += nums[i];
                }
            }
            Console.WriteLine($"{sumEvens - sumOdds}");

        }
    }
}
