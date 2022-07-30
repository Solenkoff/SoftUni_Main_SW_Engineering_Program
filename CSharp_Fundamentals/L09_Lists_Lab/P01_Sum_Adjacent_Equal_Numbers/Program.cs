using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_Sum_Adjacent_Equal_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> input = Console.ReadLine()
                                     .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                     .Select(int.Parse)
                                     .ToList();

            for (int i = 0; i < input.Count - 1; i++)
            {

                if (input[i] == input[i + 1])
                {
                    input[i] += input[i + 1];
                    input.RemoveAt(i + 1);
                    i = -1;
                }

            }
            Console.WriteLine(string.Join(' ', input));
            return;

        }
    }
}
