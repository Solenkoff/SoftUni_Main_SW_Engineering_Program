using System;
using System.Collections.Generic;
using System.Linq;

namespace _09_List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {

            int end = int.Parse(Console.ReadLine());
            List<int> dividers = Console.ReadLine()
                                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse)
                                        .ToList();

            Func<int, int, bool> predicate = (num, d) => num % d == 0;

            for (int i = 1; i <= end; i++)
            {
                if (dividers.All(d => predicate(i, d)))
                {
                    Console.Write(i + " ");
                }
            }

        }
    }
}
