using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace P02_Mirror_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"(\#|\@)[A-Za-z]{3,}\1\1[A-Za-z]{3,}\1";
        

            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(input);

            int wordPairs = matches.Count;

            List<string> mirrorWords = new List<string>();

            foreach (Match match in matches)
            {
                string[] pairs = match.Value.Split(new char[] { '#', '@' }, StringSplitOptions.RemoveEmptyEntries);

                string firstPart = pairs[0];
                string secondPart = pairs[1];

                char[] charArray = pairs[1].ToCharArray();
                Array.Reverse(charArray);
                string secondPartReversed = new string(charArray);

                if(firstPart == secondPartReversed)
                {
                    string combined = firstPart + " <=> " + secondPart;
                    mirrorWords.Add(combined);
                }
            }

            if(wordPairs == 0)
            {
                Console.WriteLine("No word pairs found!");
            }
            else
            {
                Console.WriteLine($"{wordPairs} word pairs found!");
            }

            if(mirrorWords.Count == 0)
            {
                Console.WriteLine("No mirror words!");
            }
            else
            {
                Console.WriteLine("The mirror words are:");
                Console.WriteLine(string.Join(", ", mirrorWords));
            }
        }
    }
}
