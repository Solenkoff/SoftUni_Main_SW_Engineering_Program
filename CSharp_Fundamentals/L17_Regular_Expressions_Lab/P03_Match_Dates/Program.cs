namespace P03_Match_Dates
{
    using System;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main(string[] args)
        {

            MatchCollection dates = Regex
                .Matches(Console.ReadLine(), @"(?<day>[0-9]{2})(?<separator>.)(?<month>[A-Za-z]{3})\k<separator>(\d{4})");


            foreach (Match day in dates)
            {
                Console.WriteLine($"Day: {day.Groups["day"]}, Month: {day.Groups["month"]}, Year: {day.Groups[1]}");
            }

        }
    }
}
