using System;

namespace _09_Yard_Greening
{
    class Program
    {
        static void Main(string[] args)
        {
            double squareM = double.Parse(Console.ReadLine());
            double pricePerM = 7.61;
            double amount = squareM * pricePerM;
            double discount = amount * 0.18;
            double finalAmount = amount - discount;

            Console.WriteLine($"The final price is: {finalAmount} lv.");
            Console.WriteLine($"The discount is: {discount} lv.");
        }
    }
}
