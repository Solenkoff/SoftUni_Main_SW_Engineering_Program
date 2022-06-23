using System;
using System.Linq;

namespace _06_Equal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] arr = Console.ReadLine()
                               .Split()
                               .Select(int.Parse)
                               .ToArray();

            bool isFound = false;

            for (int i = 0; i < arr.Length; i++)
            {
                int rightSum = 0;
                for (int k = i + 1; k < arr.Length; k++)
                {
                    rightSum += arr[k];
                }

                int leftSum = 0;
                for (int j = i - 1; j >= 0; j--)
                {
                    leftSum += arr[j];
                }

                if (leftSum == rightSum)
                {
                    Console.WriteLine(i);
                    isFound = true;
                    break;
                }
            }
            if (!isFound)
            {
                Console.WriteLine("no");
            }

        }
    }
}
