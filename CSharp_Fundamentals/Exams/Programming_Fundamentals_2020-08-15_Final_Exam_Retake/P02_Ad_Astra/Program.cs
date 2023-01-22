using System;
using System.Text.RegularExpressions;

namespace _02_Ad_Astra
{
    class Program
    {
        static void Main(string[] args)
        {

            string text = Console.ReadLine();

            string pattern = @"(#|\|)(?<itemname>[A-Za-z\s]+)\1(?<expiration>[0-9]{2}\/[0-9]{2}\/[0-9]{2})\1(?<calories>[0-9]+)\1";

            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(text);

            int totalCalories = 0;

            foreach (Match match in matches)
            {
                totalCalories += int.Parse(match.Groups["calories"].Value);
            }

            int days = totalCalories / 2000;

            Console.WriteLine($"You have food to last you for: {days} days!");

            foreach (Match item in matches)
            {
                Console.WriteLine($"Item: {item.Groups["itemname"].Value}, Best before: " +
                    $"{item.Groups["expiration"].Value}, Nutrition: {item.Groups["calories"].Value}");
            }

        }
    }
}
