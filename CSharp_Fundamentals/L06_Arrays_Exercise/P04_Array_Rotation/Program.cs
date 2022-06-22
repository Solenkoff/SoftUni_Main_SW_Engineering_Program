using System;
using System.Linq;

namespace _04_Array_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] nums = Console.ReadLine().Split();
            int rotationsN = int.Parse(Console.ReadLine());

            for (int i = 0; i < rotationsN; i++)
            {
                string[] currentArr = new string[nums.Length];

                for (int j = 0; j < nums.Length - 1; j++)
                {
                    currentArr[j] = nums[j + 1];
                }
                currentArr[nums.Length - 1] = nums[0];
                nums = currentArr;
            }
            Console.WriteLine(string.Join(" ", nums));

        }
    }
}
