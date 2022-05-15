using System;

namespace _06_Triples_Of_Latin_Letters
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            for (int firstSimbol = 0; firstSimbol < n; firstSimbol++)
            {
                for (int secondSimbol = 0; secondSimbol < n; secondSimbol++)
                {
                    for (int thirdSimbol = 0; thirdSimbol < n; thirdSimbol++)
                    {
                        char firstChar = (char)(97 + firstSimbol);
                        char secondChar = (char)(97 + secondSimbol);
                        char thirdChar = (char)(97 + thirdSimbol);

                        Console.WriteLine($"{firstChar}{secondChar}{thirdChar}");
                    }
                }
            }

        }
    }
}
