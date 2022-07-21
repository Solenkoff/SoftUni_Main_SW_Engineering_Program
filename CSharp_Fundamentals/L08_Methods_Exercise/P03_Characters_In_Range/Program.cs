using System;

namespace _03_Characters_In_Range
{
    class Program
    {
        static void Main(string[] args)
        {

            char firstInput = char.Parse(Console.ReadLine());
            char secondInput = char.Parse(Console.ReadLine());

            AllCharsBetweenTwoGiven(firstInput, secondInput);

        }


        private static void AllCharsBetweenTwoGiven(char firstInput, char secondInput)
        {
            int firstChar = Math.Min(firstInput, secondInput);
            int secondChar = Math.Max(firstInput, secondInput);

            for (int i = firstChar + 1; i < secondChar; i++)
            {
                Console.Write((char)i + " ");
            }
        }

    }
}
