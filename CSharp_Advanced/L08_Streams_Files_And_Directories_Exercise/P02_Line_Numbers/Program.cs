using System;
using System.IO;
using System.Linq;

namespace _02_Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = Path.Combine("Data", "Text.txt");
            var outputPath = Path.Combine("Data", "Output.txt");

            string[] lines = File.ReadAllLines(path);

            string[] result = new string[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                int lettersCount = CountOfLetters(line);
                int marksCount = CountOfPunctuation(line);

                result[i] = $"Line {i + 1}: {lines[i]}({lettersCount})({marksCount})";
            }

            File.WriteAllLines(outputPath, result);
        }


        static int CountOfLetters(string line)
        {
            int counter = 0;

            for (int i = 0; i < line.Length; i++)
            {
                char currentSymbol = line[i];
                if (char.IsLetter(currentSymbol))
                {
                    counter++;
                }
            }

            return counter;
        }


        static int CountOfPunctuation(string line)
        {
            char[] punctuationMarks = { '-', ',', '.', '!', '?', '\'' };

            int counter = 0;

            for (int i = 0; i < line.Length; i++)
            {
                char currentSymbol = line[i];
                
                if (punctuationMarks.Contains(currentSymbol))
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
