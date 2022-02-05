using System;

namespace _01_Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string projection = Console.ReadLine();
            int row = int.Parse(Console.ReadLine());
            int colums = int.Parse(Console.ReadLine());
            double income = 0;

            switch (projection)
            {
                case "Premiere":
                    income = row * colums * 12;
                    break;
                case "Normal":
                    income = row * colums * 7.50;
                    break;
                case "Discount":
                    income = row * colums * 5.00;
                    break;
            }
            Console.WriteLine($"{income:f2} leva");
        }
    }
}
