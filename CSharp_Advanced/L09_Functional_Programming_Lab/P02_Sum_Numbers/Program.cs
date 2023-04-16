using System;
using System.Linq;

namespace _02_Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] array = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                                              .Select(ParseNumber)
                                              .ToArray();

            PrintResults(array, GetCount, Sum);
           // PrintResults(array, GetCount, x =>
           // {
           //     int sum = 0;
           //     for (int i = 0; i < x.Length; i++)
           //     {
           //         sum += x[i];
           //     }
           //     return sum;
           // });

        }


        static int GetCount(int[] array)
        {
            return array.Length;
        }

        static int Sum(int[] array)
        {
            return array.Sum();
        }

        static void PrintResults(int[] array, Func<int[], int> count, Func<int[], int> sum)
        {
            Console.WriteLine(count(array));
            Console.WriteLine(sum(array));
        }

        static int ParseNumber(string number)
        {
            return int.Parse(number);
        }

    }
}
