using System;
using System.Linq;

namespace P01_Scrabble
{
    class Program
    {
        static void Main(string[] args)
        {
            string letters = Console.ReadLine();

            

            while (true)
            {
                string[] parts = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = parts[0];

                if(command == "Move")
                {
                    int index = int.Parse(parts[1]);

                    if(index >= 0 && index < 7)
                    {
                        char letter = letters[index];
                        letters = letters.Remove(index, 1);
                        letters += letter;
                    }
                }
                else if (command == "Insert" && parts[1] == "Space")
                {
                        int index = int.Parse(parts[2]);

                        letters.Insert(index, " ");
                }
                else if (command == "Reverse")
                {
                    string subString = parts[1];

                    if(letters.Contains(subString))
                    {
                        char[] charArray = subString.ToCharArray();
                        Array.Reverse(charArray);
                        string reversed = new string(charArray);
                        int index = letters.IndexOf(subString);

                        letters = letters.Remove(index, subString.Length);

                        letters += reversed;
                    }
                }
                else if (command == "Exchange" && parts[1] == "Tiles")
                {
                    string newLetters = parts[2];

                    letters = letters.Remove(0, newLetters.Length);
                    letters = newLetters + letters;
                    char[] lettersArray = letters.ToCharArray();

                    Console.WriteLine(string.Join(" ", lettersArray));

                    return;
                }
                else if (command == "Pass" && parts.Length == 1)
                {
                    char[] lettersArray = letters.ToCharArray();

                    Console.WriteLine(string.Join(" ", lettersArray));

                    return;
                }
                else if (command == "Play" && parts.Length == 1)
                {
                    string[] splitLetters = letters.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    string finalWord = splitLetters[0];

                    Console.WriteLine($"You are playing with the word {finalWord}.");

                    return;
                }

            }


        }
    }
}
