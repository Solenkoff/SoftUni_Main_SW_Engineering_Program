using System;

namespace _04_Fishing_Boat
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fisherNum = int.Parse(Console.ReadLine());
            double discount = 0;
            double price = 0;

            if (season == "Spring")
            {
                if (fisherNum <= 6)
                {
                    discount = 3000 * 0.10;
                    price = 3000 - discount;
                }
                else if (fisherNum >= 7 && fisherNum <= 11)
                {
                    discount = 3000 * 0.15;
                    price = 3000 - discount;
                }
                else if (fisherNum >= 12)
                {
                    discount = 3000 * 0.25;
                    price = 3000 - discount;
                }
            }
            else if (season == "Summer")
            {
                if (fisherNum <= 6)
                {
                    discount = 4200 * 0.10;
                    price = 4200 - discount;
                }
                else if (fisherNum >= 7 && fisherNum <= 11)
                {
                    discount = 4200 * 0.15;
                    price = 4200 - discount;
                }
                else if (fisherNum >= 12)
                {
                    discount = 4200 * 0.25;
                    price = 4200 - discount;
                }
            }
            else if (season == "Autumn")
            {
                if (fisherNum <= 6)
                {
                    discount = 4200 * 0.10;
                    price = 4200 - discount;
                }
                else if (fisherNum >= 7 && fisherNum <= 11)
                {
                    discount = 4200 * 0.15;
                    price = 4200 - discount;
                }
                else if (fisherNum >= 12)
                {
                    discount = 4200 * 0.25;
                    price = 4200 - discount;
                }
            }
            else if (season == "Winter")
            {
                if (fisherNum <= 6)
                {
                    discount = 2600 * 0.10;
                    price = 2600 - discount;
                }
                else if (fisherNum >= 7 && fisherNum <= 11)
                {
                    discount = 2600 * 0.15;
                    price = 2600 - discount;
                }
                else if (fisherNum >= 12)
                {
                    discount = 2600 * 0.25;
                    price = 2600 - discount;
                }
            }
            if (fisherNum % 2 == 0 && season != "Autumn")
            {
                discount = price * 0.05;
                price -= discount;
            }
            if (budget >= price)
            {
                Console.WriteLine($"Yes! You have {budget - price:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {price - budget:f2} leva.");
            }
        }
    }
}
