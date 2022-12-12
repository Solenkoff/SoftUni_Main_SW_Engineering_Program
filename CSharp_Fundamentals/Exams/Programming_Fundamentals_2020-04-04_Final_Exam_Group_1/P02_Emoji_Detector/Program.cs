using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace P02_Emoji_Detector
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();

            long coolThreshold = 1L;

            foreach (var item in input)
            {
                if (char.IsDigit(item))
                {
                    coolThreshold = coolThreshold * (item - '0');
                }
            }

            string pattern = @"(:{2}|\*{2})(?<value>[A-Z][a-z]{2,})(\1)";

            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(input);

            List<string> coolEmojis = new List<string>();

            foreach (Match match in matches)
            {
                int sum = match.Groups["value"].Value.Sum(ch => (int)ch);

                if(sum >= coolThreshold)
                {
                    coolEmojis.Add(match.Value);
                }
            }

            Console.WriteLine($"Cool threshold: {coolThreshold}");
            Console.WriteLine($"{matches.Count} emojis found in the text. The cool ones are:");
            foreach (var item in coolEmojis)
            {
                Console.WriteLine(item);
            }
        }
    }
}
