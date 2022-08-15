using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_Append_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> input = Console.ReadLine()
                                       .Split("|")
                                       .ToList();

            input.Reverse();

            List<string> result = new List<string>();

            foreach (string currentItem in input)
            {
                string[] numbers = currentItem
                                     .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                     .ToArray();
                foreach (string numsToAdd in numbers)
                {
                    result.Add(numsToAdd);
                }
            }

            Console.WriteLine(string.Join(' ', result));

        }
    }
}
