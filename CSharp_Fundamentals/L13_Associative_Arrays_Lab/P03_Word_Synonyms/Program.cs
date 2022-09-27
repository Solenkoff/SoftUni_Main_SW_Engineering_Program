namespace P03_Word_Synonyms
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<string>> words = new Dictionary<string, List<string>>();

            for (int i = 0; i < n; i++)
            {
                string readLine = Console.ReadLine();
                string synonym = Console.ReadLine();

                if (!words.ContainsKey(readLine))
                {

                    words.Add(readLine, new List<string>());
                }
                words[readLine].Add(synonym);
            }

            foreach (var word in words)
            {
                Console.WriteLine($"{word.Key} - {string.Join(", ", word.Value)}");
            }

        }
    }
}
