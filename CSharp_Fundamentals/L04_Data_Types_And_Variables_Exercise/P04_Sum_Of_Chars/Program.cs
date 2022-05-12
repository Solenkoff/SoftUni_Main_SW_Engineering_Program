using System;

namespace _04_Sum_Of_Chars
{
    class Program
    {
        static void Main(string[] args)
        {

            int nCharacters = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = 0; i < nCharacters; i++)
            {
                char input = char.Parse(Console.ReadLine());
                sum += input;
            }
            Console.WriteLine($"The sum equals: {sum}");

        }
    }
}
