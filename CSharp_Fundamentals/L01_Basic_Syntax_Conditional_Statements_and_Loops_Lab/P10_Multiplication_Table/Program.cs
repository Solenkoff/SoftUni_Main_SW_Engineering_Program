using System;

namespace P10_Multiplication_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputNumber = int.Parse(Console.ReadLine());

            for (int i = 1; i <= 10; i++)
            {
                int multiplication = inputNumber * i;
                Console.WriteLine($"{inputNumber} X {i} = {multiplication}");
            }
        }
    }
}
