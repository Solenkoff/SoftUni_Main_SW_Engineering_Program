using System;

namespace _07v2_Vending_Machine
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();
            double totalMoneyIn = 0;

            while (input != "Start")
            {
                double currentCoin = double.Parse(input);

                bool isValidCoin = currentCoin == 0.1 ||
                               currentCoin == 0.2 ||
                               currentCoin == 0.5 ||
                               currentCoin == 1.0 ||
                               currentCoin == 2.0;

                if (isValidCoin == true)
                {
                    totalMoneyIn += currentCoin;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {currentCoin}");
                }

                input = Console.ReadLine();
            }

            string product = Console.ReadLine();
            while (product != "End")
            {
                double productPrice = 0;
                // “Nuts”, “Water”, “Crisps”, “Soda”, “Coke”. 
                //   2.0,     0.7,    1.5,      0.8,    1.0 
                switch (product)
                {
                    case "Nuts":
                        productPrice = 2.0;
                        break;
                    case "Water":
                        productPrice = 0.7;
                        break;
                    case "Crisps":
                        productPrice = 1.5;
                        break;
                    case "Soda":
                        productPrice = 0.8;
                        break;
                    case "Coke":
                        productPrice = 1.0;
                        break;
                    default:
                        Console.WriteLine("Invalid product");
                        product = Console.ReadLine();
                        continue;
                }
                if (productPrice <= totalMoneyIn)
                {
                    totalMoneyIn -= productPrice;
                    Console.WriteLine($"Purchased {product.ToLower()}");
                }
                else
                {
                    Console.WriteLine("Sorry, not enough money");
                }

                product = Console.ReadLine();
            }
            Console.WriteLine($"Change: {totalMoneyIn:f2}");

        }
    }
}
