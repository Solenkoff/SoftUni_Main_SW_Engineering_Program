using System;

namespace _06_Number_In_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            bool isValid = number >= -100 && number <= 100 && number != 0;
            if (isValid)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
