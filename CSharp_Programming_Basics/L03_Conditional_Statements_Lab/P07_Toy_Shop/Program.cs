using System;

namespace _07_Toy_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            double tripPrice = double.Parse(Console.ReadLine());
            int puzzleNum = int.Parse(Console.ReadLine());
            int dollsNum = int.Parse(Console.ReadLine());
            int teddyNum = int.Parse(Console.ReadLine());
            int mignionNum = int.Parse(Console.ReadLine());
            int trucksNum = int.Parse(Console.ReadLine());

            double puzzlePrice = 2.60;
            double dollPrice = 3.00;
            double teddyPrice = 4.10;
            double mignionPrice = 8.20;
            double truckPrice = 2;
            double discount = 0;
            double income = puzzlePrice * puzzleNum + dollPrice * dollsNum + teddyPrice * teddyNum + truckPrice * trucksNum + mignionPrice * mignionNum;
            int toys = puzzleNum + dollsNum + teddyNum + mignionNum + trucksNum;

            if (toys >= 50)
            {
                discount = income * 0.25;
                income -= discount;
            }

            double rent = income * 0.10;
            double profit = income - rent;
            if (tripPrice > profit)
            {
                double neededMoney = tripPrice - profit;
                Console.WriteLine($"Not enough money! {neededMoney:f2} lv needed.");
            }
            else
            {
                double leftMoney = profit - tripPrice;
                Console.WriteLine($"Yes! {leftMoney:f2} lv left.");

            }
        }
    }
}
