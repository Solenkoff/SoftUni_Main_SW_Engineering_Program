using System;

namespace _01_Valid_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] input = Console.ReadLine()
                                   .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in input)
            {
                bool isVallid = true;
                foreach (char charachter in word)
                {
                    if (!Char.IsLetterOrDigit(charachter) && charachter != '_' && charachter != '-')
                    {
                        isVallid = false;
                    }
                }

                if (isVallid && word.Length >= 3 && word.Length <= 16)
                {
                    Console.WriteLine(word);
                }
            }

        }
    }
}
