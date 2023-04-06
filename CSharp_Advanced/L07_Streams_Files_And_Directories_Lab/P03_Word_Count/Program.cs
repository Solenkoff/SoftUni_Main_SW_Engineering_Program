using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03_Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {

            string expectedResultPath = Path.Combine("Data", "ExpectedResult.txt");
            string textPath = Path.Combine("Data", "Text.txt");
            string wordsPath = Path.Combine("Data", "Words.txt");

            string[] words = File.ReadAllLines(wordsPath);

            Dictionary<string, int> wordsCount = new Dictionary<string, int>();

            foreach (var word in words)
            {
                wordsCount.Add(word.ToLower(), 0);
            }

            string text = File.ReadAllText(textPath).ToLower();

            string[] textWords = text.Split(new string[] { " ", ",", ".", "!", "?", "-", Environment.NewLine }
                                     , StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in textWords)
            {
                if (wordsCount.ContainsKey(word))
                {
                    wordsCount[word]++;
                }
            }

            Dictionary<string, int> sortedWords = wordsCount.OrderByDescending(x => x.Value)
                                                            .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            List<string> outputLines = sortedWords.Select(x => $"{x.Key} - {x.Value}")
                                                  .ToList();

            File.WriteAllLines(expectedResultPath, outputLines);

        }
    }
}
