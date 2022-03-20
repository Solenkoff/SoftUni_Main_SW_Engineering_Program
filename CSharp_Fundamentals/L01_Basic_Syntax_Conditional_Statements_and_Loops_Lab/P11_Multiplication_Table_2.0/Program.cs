using System;

namespace P11_Multiplication_Table_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputNumber = int.Parse(Console.ReadLine());
            int multiplier = int.Parse(Console.ReadLine());

            if (multiplier <= 10)
            {
                for (int i = multiplier; i <= 10; i++)
                {
                    int multiplication = inputNumber * i;
                    Console.WriteLine($"{inputNumber} X {i} = {multiplication}");
                }
            }
            else if (multiplier > 10)
            {
                int multiplication = inputNumber * multiplier;
                Console.WriteLine($"{inputNumber} X {multiplier} = {multiplication}");
            }
        }
    }
}
