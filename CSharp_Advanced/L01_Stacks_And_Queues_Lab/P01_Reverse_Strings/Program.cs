using System;
using System.Collections;
using System.Collections.Generic;

namespace _01_Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();

            Stack<char> reverseInput = new Stack<char>();

            foreach(char character in input)
            {
                reverseInput.Push(character);
            }

            while (reverseInput.Count != 0)
            {
                Console.Write(reverseInput.Pop());
            }

        }
    }
}
