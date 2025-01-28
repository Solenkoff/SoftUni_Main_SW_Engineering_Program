using System;

namespace _04_Reverse_String
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();

            string reversInput = string.Empty;
            for (int i = input.Length - 1; i >= 0; i--)
            {
                reversInput += input[i];
            }
            Console.WriteLine(reversInput);

        }
    }
}
