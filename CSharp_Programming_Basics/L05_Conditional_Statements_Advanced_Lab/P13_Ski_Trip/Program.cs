using System;

namespace _13_Ski_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string kindOfRoom = Console.ReadLine();
            string review = Console.ReadLine();
            double price = 0;
            double discount = 0;

            switch (kindOfRoom)
            {
                case "room for one person":
                    if (days >= 10 || (days > 10 && days <= 15) || days > 15)
                    {
                        price = (days - 1) * 18;
                    }
                    break;
                case "apartment":
                    if (days <= 10)
                    {
                        price = (days - 1) * 25;
                        discount = price * 0.30;
                        price -= discount;
                    }
                    else if (days > 10 && days <= 15)
                    {
                        price = (days - 1) * 25;
                        discount = price * 0.35;
                        price -= discount;
                    }
                    else
                    {
                        price = (days - 1) * 25;
                        discount = price * 0.50;
                        price -= discount;
                    }
                    break;
                case "president apartment":
                    if (days <= 10)
                    {
                        price = (days - 1) * 35;
                        discount = price * 0.10;
                        price -= discount;
                    }
                    else if (days > 10 && days <= 15)
                    {
                        price = (days - 1) * 35;
                        discount = price * 0.15;
                        price -= discount;
                    }
                    else
                    {
                        price = (days - 1) * 35;
                        discount = price * 0.20;
                        price -= discount;
                    }
                    break;
            }
            if (review == "positive")
            {
                price *= 1.25;
            }
            else
            {
                price *= 0.90;
            }
            Console.WriteLine($"{price:f2}");
        }
    }
}
