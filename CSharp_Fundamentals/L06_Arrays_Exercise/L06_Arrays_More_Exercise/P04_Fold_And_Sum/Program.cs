using System;
using System.Linq;

namespace P04_Fold_And_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArr = Console.ReadLine()
                                    .Split()
                                    .Select(int.Parse)
                                    .ToArray();

            int k = inputArr.Length / 4;
            int[] arr = new int[2 * k];

            for (int i = 0; i < k; i++)
            {
                arr[i] = inputArr[k - (i + 1)] + inputArr[k + i];
                arr[arr.Length - 1 - i] = inputArr[arr.Length - 1 - i + k] + inputArr[(arr.Length - 1 - i) + (k + 2 * i + 1)];
            }
            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
