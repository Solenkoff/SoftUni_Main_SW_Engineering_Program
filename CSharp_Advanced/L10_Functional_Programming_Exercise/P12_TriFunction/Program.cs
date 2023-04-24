﻿using System;
using System.Linq;

namespace _12_TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                                   .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                   .Select(int.Parse)
                                   .ToArray();

            Array.Sort(numbers, (a, b) =>
            {
                if (a % 2 != 0 && b % 2 == 0)
                {
                    return 1;
                }
                else if (a % 2 == 0 && b % 2 != 0)
                {
                    return -1;
                }

                int temp = a.CompareTo(b);

                return temp;
            });

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
