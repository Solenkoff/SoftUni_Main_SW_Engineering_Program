using System;

namespace _05_Account_Balance
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            double balance = 0.0;


            while (command != "NoMoreMoney")
            {
                double deposit = double.Parse(command);
                if (deposit < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                balance += deposit;
                Console.WriteLine($"Increase: {deposit:f2}");
                command = Console.ReadLine();
            }
            Console.WriteLine($"Total: {balance:f2}");
        }
    }
}
