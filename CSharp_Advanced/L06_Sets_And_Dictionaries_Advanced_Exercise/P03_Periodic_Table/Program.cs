using System;
using System.Collections.Generic;

namespace _03_Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            SortedSet<string> elements = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] elsementsInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in elsementsInput)
                {
                    elements.Add(item);
                }
            }

            foreach (var item in elements)
            {
                Console.Write(item + " ");
            }

        }
    }
}
