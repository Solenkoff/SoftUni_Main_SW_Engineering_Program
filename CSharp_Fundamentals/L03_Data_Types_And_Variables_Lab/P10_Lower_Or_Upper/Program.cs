using System;

namespace _10_Lower_Or_Upper
{
    class Program
    {
        static void Main(string[] args)
        {

            char character = char.Parse(Console.ReadLine());

            if (char.IsUpper(character))
            {
                Console.WriteLine("upper-case");
            }
            else if (char.IsLower(character))
            {
                Console.WriteLine("lower-case");
            }

        }
    }
}
