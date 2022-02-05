using System;

namespace _03_New_House
{
    class Program
    {
        static void Main(string[] args)
        {
            string flowers = Console.ReadLine();
            int numFlowers = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());
            double discount = 0;
            double price = 0;

            switch (flowers)
            {
                case "Roses":
                    if (numFlowers > 80)
                    {
                        discount = (numFlowers * 5) * 0.10;
                        price = (numFlowers * 5) - discount;
                    }
                    else
                    {
                        price = numFlowers * 5;
                    }
                    break;
                case "Dahlias":
                    if (numFlowers > 90)
                    {
                        discount = (numFlowers * 3.80) * 0.15;
                        price = (numFlowers * 3.80) - discount;
                    }
                    else
                    {
                        price = numFlowers * 3.80;
                    }
                    break;
                case "Tulips":
                    if (numFlowers > 80)
                    {
                        discount = (numFlowers * 2.80) * 0.15;
                        price = (numFlowers * 2.80) - discount;
                    }
                    else
                    {
                        price = numFlowers * 2.80;
                    }
                    break;
                case "Narcissus":
                    if (numFlowers < 120)
                    {
                        discount = (numFlowers * 3) * 0.15;
                        price = (numFlowers * 3) + discount;
                    }
                    else
                    {
                        price = numFlowers * 3;
                    }
                    break;
                case "Gladiolus":
                    if (numFlowers < 80)
                    {
                        discount = (numFlowers * 2.50) * 0.20;
                        price = (numFlowers * 2.50) + discount;
                    }
                    else
                    {
                        price = numFlowers * 2.50;
                    }
                    break;
            }
            if (budget >= price)
            {
                Console.WriteLine($"Hey, you have a great garden with {numFlowers} {flowers} and {budget - price:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {price - budget:f2} leva more.");
            }
        }
    }
}
