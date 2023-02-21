using System;
using System.Text.RegularExpressions;

namespace _02_Problem_Valid_Inputs
{
    class Program
    {
        static void Main(string[] args)
        {

            int nInputs = int.Parse(Console.ReadLine());

            string pattern = @"^\|(?<name>[A-Z]{4,})\|\:\#(?<title>[A-Za-z]+\s[A-Za-z]+)\#$";

            Regex regex = new Regex(pattern);

            for (int i = 0; i < nInputs; i++)
            {
                string bossname = Console.ReadLine();

                Match match = regex.Match(bossname);

                if (match.Success)
                {
                    Console.WriteLine($"{match.Groups["name"].Value}, The {match.Groups["title"].Value}");
                    Console.WriteLine($">> Strength: {match.Groups["name"].Value.Length}");
                    Console.WriteLine($">> Armour: {match.Groups["title"].Value.Length}");
                }
                else
                {
                    Console.WriteLine("Access denied!");
                }
            }

        }
    }
}
