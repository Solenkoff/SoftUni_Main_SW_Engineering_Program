using System;
using System.Collections.Generic;

namespace _05_Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();

            SortedDictionary<char, int> accurrances = new SortedDictionary<char, int>();

            foreach (var ch in input)
            {
                if(!accurrances.ContainsKey(ch))
                {
                    accurrances.Add(ch, 0);
                }

                accurrances[ch]++;
            }

            foreach (var ch in accurrances)
            {
                Console.WriteLine($"{ch.Key}: {ch.Value} time/s");

            }
        }
    }
}
