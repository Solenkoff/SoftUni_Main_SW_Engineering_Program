using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02_Race
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> participants = Console.ReadLine()
                                             .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                             .ToList();

            Dictionary<string, int> validRacers = new Dictionary<string, int>();

            foreach (var name in participants)
            {
                validRacers.Add(name, 0);
            }

            string namePattern = @"[\W\d]";
            string distancePattern = @"[^\d]";

            string input = Console.ReadLine();

            while (input != "end of race")
            {

                string name = Regex.Replace(input, namePattern, "");

                if (validRacers.ContainsKey(name))
                {
                    string distanceNums = Regex.Replace(input, distancePattern, "");
                    int distance = 0;

                    foreach (var digit in distanceNums)
                    {
                        int currentDigit = int.Parse(digit.ToString());
                        distance += currentDigit;
                    }

                    validRacers[name] += distance;
                }

                input = Console.ReadLine();
            }

            List<string> winners = new List<string>();
            foreach (var item in validRacers.OrderByDescending(x => x.Value))
            {
                winners.Add(item.Key);
            }

            Console.WriteLine($"1st place: {winners[0]}");
            Console.WriteLine($"2nd place: {winners[1]}");
            Console.WriteLine($"3rd place: {winners[2]}");

        }
    }
}
