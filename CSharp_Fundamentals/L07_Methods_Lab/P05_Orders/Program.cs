using System;

namespace _05_Orders
{
    class Program
    {
        static void Main(string[] args)
        {

            string productOrdered = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());

            double price = 0.0;

            switch (productOrdered)
            {
                case "coffee":
                    price = 1.50;
                    PrintTotal(price, quantity);
                    break;
                case "water":
                    price = 1.00;
                    PrintTotal(price, quantity);
                    break;
                case "coke":
                    price = 1.40;
                    PrintTotal(price, quantity);
                    break;
                case "snacks":
                    price = 2.00;
                    PrintTotal(price, quantity);
                    break;

            }

        }

        static void PrintTotal(double price, int quantity)
        {
            double total = price * quantity;
            Console.WriteLine($"{total:f2}");
        }
    }
}
