using System;
using System.Text.RegularExpressions;

namespace _02_Valid_Registration
{
    class Program
    {
        static void Main(string[] args)
        {

            int numLines = int.Parse(Console.ReadLine());

            string pattern = @"U\$(?<username>[A-Z][a-z]{2,})U\$P@\$(?<password>[A-Za-z]{5,}\d+)P@\$";

            Regex regex = new Regex(pattern);

            int registrationsCount = 0;

            for (int i = 0; i < numLines; i++)
            {
                string input = Console.ReadLine();

                Match match = regex.Match(input);

                if (match.Success)
                {
                    string username = match.Groups["username"].Value;
                    string password = match.Groups["password"].Value;
                    registrationsCount++;
                    Console.WriteLine("Registration was successful");
                    Console.WriteLine($"Username: {username}, Password: {password }");
                }
                else
                {
                    Console.WriteLine("Invalid username or password");
                }
            }

            Console.WriteLine($"Successful registrations: {registrationsCount}");

        }
    }
}
