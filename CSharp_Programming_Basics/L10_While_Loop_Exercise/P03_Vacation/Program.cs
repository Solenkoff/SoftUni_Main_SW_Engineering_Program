using System;

namespace _03_Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double vacationPrice = double.Parse(Console.ReadLine());
            double currentMoney = double.Parse(Console.ReadLine());
            int days = 0;
            int daysSpent = 0;
            while (currentMoney < vacationPrice)
            {
                days++;
                string input = Console.ReadLine();
                double money = double.Parse(Console.ReadLine());
                if (input == "spend")
                {
                    daysSpent++;
                    if (daysSpent == 5)
                    {
                        Console.WriteLine("You can't save the money.");
                        Console.WriteLine($"{days}");
                        break;
                    }
                    currentMoney -= money;
                    if (currentMoney < 0)
                    {
                        currentMoney = 0;
                    }
                }
                else if (input == "save")
                {
                    daysSpent = 0;
                    currentMoney += money;
                }
            }
            if (currentMoney >= vacationPrice)
            {
                Console.WriteLine($"You saved the money for {days} days.");
            }
        }
    }
}
