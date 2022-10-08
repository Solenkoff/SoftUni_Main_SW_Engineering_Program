using System;
using System.Collections.Generic;

namespace _01_Count_Chars_In_A_String
{
    class Program
    {
        static void Main(string[] args)
        {

            char[] input = Console.ReadLine().ToCharArray();
            Dictionary<char, int> occurences = new Dictionary<char, int>();

            foreach (var character in input)
            {
                if (character != ' ')
                {
                    if (occurences.ContainsKey(character))
                    {
                        occurences[character]++;
                    }
                    else
                    {
                        occurences.Add(character, 1);
                    }
                }
            }

            foreach (var character in occurences)
            {
                char charKey = character.Key;
                int charValue = character.Value;

                Console.WriteLine($"{charKey} -> {charValue}");
            }

        }
    }
}
