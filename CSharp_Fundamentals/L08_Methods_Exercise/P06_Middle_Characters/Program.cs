using System;

namespace _06_Middle_Characters
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();

            PrintTheMiddleChar(input);

        }

        private static void PrintTheMiddleChar(string input)
        {
            if (input.Length % 2 == 0)
            {
                string result = char.ToString(input[input.Length / 2 - 1]) +
                                char.ToString(input[input.Length / 2]);
                Console.WriteLine(result);
            }
            else if (input.Length % 2 == 1)
            {
                char result = input[input.Length / 2];
                Console.WriteLine(result);
            }
        }

    }
}
