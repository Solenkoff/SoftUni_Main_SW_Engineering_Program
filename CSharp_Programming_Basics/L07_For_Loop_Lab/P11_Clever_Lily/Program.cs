using System;

namespace _11_Clever_Lily
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double washmachine = double.Parse(Console.ReadLine());
            double toysPrice = double.Parse(Console.ReadLine());
            double presentMoney = 10;
            double presentToys = 0;
            double savings = 0;

            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    savings += presentMoney;
                    presentMoney += 10;
                    savings -= 1;
                }
                else
                {
                    presentToys += 1;
                }
            }
            savings += presentToys * toysPrice;

            if (washmachine <= savings)
            {
                Console.WriteLine($"Yes! {savings - washmachine:f2}");
            }
            else
            {
                Console.WriteLine($"No! {washmachine - savings:f2}");
            }
        }
    }
}
