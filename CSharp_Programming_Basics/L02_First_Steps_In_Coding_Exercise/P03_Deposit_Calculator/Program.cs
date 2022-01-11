using System;

namespace _03_Deposit_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double depositAmount = double.Parse(Console.ReadLine());
            int depositTime = int.Parse(Console.ReadLine());
            double anualInterest = double.Parse(Console.ReadLine());
            double amount = depositAmount + (depositTime * (depositAmount * anualInterest / 100) / 12);

            Console.WriteLine(amount);
        }
    }
}
