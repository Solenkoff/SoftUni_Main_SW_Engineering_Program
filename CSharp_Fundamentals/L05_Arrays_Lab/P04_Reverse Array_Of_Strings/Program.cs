using System;
using System.Linq;

namespace _04_Reverse_Array_Of_Strings
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] words = Console.ReadLine().Split().ToArray();

            for (int i = words.Length - 1; i >= 0; i--)
            {
                Console.Write($"{words[i]} ");
            }

        }
    }
}
