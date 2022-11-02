using System;

namespace _04_Caesar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();
            string encryptedString = string.Empty;

            foreach (var item in input)
            {
                char newChar = (char)(item + 3);
                encryptedString += newChar;
            }

            Console.WriteLine(encryptedString);

        }
    }
}
