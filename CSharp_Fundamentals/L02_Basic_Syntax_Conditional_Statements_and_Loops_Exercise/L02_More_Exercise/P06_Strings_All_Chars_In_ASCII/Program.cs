using System;

namespace _06_Strings_All_Chars_In_ASCII
{
    class Program
    {
        static void Main(string[] args)
        {

            string helloWorld = "Hello, world!";
            foreach (char c in helloWorld)
            {
                Console.WriteLine(c + ": " + (int)c);
            }

        }
    }
}
