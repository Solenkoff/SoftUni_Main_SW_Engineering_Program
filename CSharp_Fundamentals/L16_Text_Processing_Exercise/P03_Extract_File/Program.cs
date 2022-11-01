using System;

namespace _03_Extract_File
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] inputString = Console.ReadLine().Split('\\', StringSplitOptions.RemoveEmptyEntries);

            string[] outputString = inputString[inputString.Length - 1].Split('.');

            Console.WriteLine($"File name: {outputString[0]}");
            Console.WriteLine($"File extension: {outputString[1]}");

        }
    }
}
