using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_Count_Same_Values_In_Array
{
    class Program
    {
        static void Main(string[] args)
        {

            double[] nums = Console.ReadLine()
                                   .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                   .Select(double.Parse)
                                   .ToArray();

            Dictionary<double, int> numsAppearances = new Dictionary<double, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if(!numsAppearances.ContainsKey(nums[i]))
                {
                    numsAppearances.Add(nums[i], 0);

                }

                numsAppearances[nums[i]]++;
                
            }

            foreach (var num in numsAppearances)
            {
                Console.WriteLine($"{num.Key} - {num.Value} times");
            }

        }
    }
}
