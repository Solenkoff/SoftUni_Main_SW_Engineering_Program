namespace P06_Extract_Emails
{
    using System;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();

            string pattern = @"(?<=\s)(?<user>[A-Za-z0-9]+[.-]*\w*)*@(?<host>[a-z]+?([.-][a-z]*)*(\.[a-z]{2,}))";

            var correct = Regex.Matches(input, pattern);

            Console.WriteLine(String.Join(Environment.NewLine, correct));

        }
    }
}
