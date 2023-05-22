using System;
using System.Linq;

namespace _03_Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] integers = Console.ReadLine()
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                    .Select(n => int.Parse(n))
                                    .ToArray();

            Func<int[], int> smallest = numbers =>
            {
                int minNum = int.MaxValue;

                foreach (var num in numbers)
                {
                    if (num < minNum)
                    {
                        minNum = num;
                    }
                }
                return minNum;
            };

            int minNumber = smallest(integers);
            Console.WriteLine(minNumber);

        }
    }
}
