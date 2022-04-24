using System;

namespace _09_Chars_To_String
{
    class Program
    {
        static void Main(string[] args)
        {

            char char1 = char.Parse(Console.ReadLine());
            char char2 = char.Parse(Console.ReadLine());
            char char3 = char.Parse(Console.ReadLine());

            string oneString = char1.ToString() + char2.ToString() + char3.ToString();
            Console.WriteLine(oneString);

        }
    }
}
