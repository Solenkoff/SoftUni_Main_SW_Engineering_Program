using System;

namespace _02_Password
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            string password = Console.ReadLine();
            string input = Console.ReadLine();
            for (; ; )
            {
                if (input == password)
                {
                    break;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Welcome {name}!");
        }
    }
}
