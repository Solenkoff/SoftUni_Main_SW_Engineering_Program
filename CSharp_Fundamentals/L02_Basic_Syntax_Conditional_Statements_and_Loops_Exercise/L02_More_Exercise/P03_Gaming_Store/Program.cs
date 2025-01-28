using System;

namespace _03_Gaming_Store
{
    class Program
    {
        static void Main(string[] args)
        {

            double input = double.Parse(Console.ReadLine());
            double currentBalance = input;

            double gamePrice = 0.0;
            string gameToBuy = Console.ReadLine();

            while (gameToBuy != "Game Time")
            {
                switch (gameToBuy)
                {
                    case "OutFall 4":
                        gamePrice = 39.99;
                        break;
                    case "CS: OG":
                        gamePrice = 15.99;
                        break;
                    case "Zplinter Zell":
                        gamePrice = 19.99;
                        break;
                    case "Honored 2":
                        gamePrice = 59.99;
                        break;
                    case "RoverWatch":
                        gamePrice = 29.99;
                        break;
                    case "RoverWatch Origins Edition":
                        gamePrice = 39.99;
                        break;
                    default:
                        Console.WriteLine("Not Found");
                        gameToBuy = Console.ReadLine();
                        continue;
                }
                if (gamePrice > currentBalance)
                {
                    Console.WriteLine("Too Expensive");
                }
                else
                {
                    Console.WriteLine($"Bought {gameToBuy}");
                    currentBalance -= gamePrice;
                }
                if (currentBalance == 0.0)
                {
                    Console.WriteLine("Out of money!");
                    return;
                }
                gameToBuy = Console.ReadLine();
            }
            Console.WriteLine($"Total spent: ${input - currentBalance:f2}. Remaining: ${currentBalance:f2}");

        }
    }
}
