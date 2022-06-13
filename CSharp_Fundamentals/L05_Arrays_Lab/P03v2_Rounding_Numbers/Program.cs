using System;
using System.Linq;

namespace _03v2_Rounding_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {

            double[] nums = Console.ReadLine()
                                   .Split()
                                   .Select(double.Parse)
                                   .ToArray();
            int[] integers = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                integers[i] = (int)Math.Round(nums[i], MidpointRounding.AwayFromZero);
                if (integers[i] == -0)
                {
                    integers[i] = 0;
                }

            }

            for (int i = 0; i < nums.Length; i++)
            {
                Console.WriteLine($"{nums[i]} => {integers[i]}");
            }

        }
    }
}
