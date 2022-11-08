namespace P01_Match_Full_Name
{
    using System;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main(string[] args)
        {

            MatchCollection matches = Regex.Matches(Console.ReadLine(), @"\b[A-Z][a-z]+ [A-Z][a-z]+");

            foreach (Match match in matches)
            {
                Console.Write($"{match.Value} ");
            }

            Console.WriteLine();

        }
    }
}
