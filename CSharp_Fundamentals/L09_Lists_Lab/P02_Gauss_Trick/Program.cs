using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_Gauss__Trick
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> nums = Console.ReadLine()
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToList();
            nums.Add(nums[0]);
            nums.RemoveAt(0);

            Console.WriteLine(string.Join(" ", nums));

        }
    }
}
