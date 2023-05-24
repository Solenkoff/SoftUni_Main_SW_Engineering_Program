using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_Find_Evens_Or_Odd
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] bounds = Console.ReadLine()
                                  .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                  .Select(int.Parse)
                                  .ToArray();

            int lowBound = bounds.Min();
            int highBound = bounds.Max();

            string criteria = Console.ReadLine();

            Func<int, int, List<int>> selection = (s, e) =>
            {
                List<int> nums = new List<int>();

                for (int i = s; i <= e; i++)
                {
                    nums.Add(i);
                }

                return nums;

            };

            List<int> numbers = selection(lowBound, highBound) ;

            Predicate<int> predicate = n => true;

            if (criteria == "odd")
            {
                predicate = n => n % 2 != 0;
            }
            else if (criteria == "even")
            {
                predicate = n => n % 2 == 0;
            }

            Console.WriteLine(string.Join(" ", MyWhere(numbers, predicate)));

        }


        static List<int> MyWhere(List<int> numbers, Predicate<int> predicate)
        {
            List<int> newNumbers = new List<int>();

            foreach (var num in numbers)
            {
                if (predicate(num))
                {
                    newNumbers.Add(num);
                }
            }

            return newNumbers;

        }
    }
}
