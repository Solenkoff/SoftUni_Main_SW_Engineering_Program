using System;

namespace _02_Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {

            string text = Console.ReadLine().ToLower();

            VowelsCount(text);

        }


        private static void VowelsCount(string text)
        {
            int vowelsCount = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == 'a' || text[i] == 'e' || text[i] == 'i' ||
                    text[i] == 'o' || text[i] == 'u' || text[i] == 'y')
                {
                    vowelsCount++;
                }
            }

            Console.WriteLine(vowelsCount);
        }

    }
}
