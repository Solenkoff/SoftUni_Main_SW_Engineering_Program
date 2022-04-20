using System;

namespace _07_Concat_Names
{
    class Program
    {
        static void Main(string[] args)
        {

            string name1 = Console.ReadLine();
            string name2 = Console.ReadLine();
            string delimiter = Console.ReadLine();

            string result = name1 + delimiter + name2;
            Console.WriteLine(result);

        }
    }
}
