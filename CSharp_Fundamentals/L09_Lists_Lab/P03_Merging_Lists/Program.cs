namespace P03_Merging_Lists
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {

            List<int> firstLine = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> secondLine = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            for (int i = Math.Min(firstLine.Count, secondLine.Count) - 1; i >= 0; i--)
            {
                secondLine.Insert(i, firstLine[i]);
            }

            if (firstLine.Count > secondLine.Count / 2)
            {
                firstLine.RemoveRange(0, secondLine.Count / 2);
                secondLine.AddRange(firstLine);
            }

            Console.WriteLine(string.Join(" ", secondLine));

        }
    }
}
