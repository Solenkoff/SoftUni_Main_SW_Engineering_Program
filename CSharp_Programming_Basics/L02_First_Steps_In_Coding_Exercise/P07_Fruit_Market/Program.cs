using System;

namespace _07_Fruit_Market
{
    class Program
    {
        static void Main(string[] args)
        {
            double berriesPrice = double.Parse(Console.ReadLine());
            double bananaQuantity = double.Parse(Console.ReadLine());
            double orangeQuantity = double.Parse(Console.ReadLine());
            double raspberryQuantity = double.Parse(Console.ReadLine());
            double berriesQuantity = double.Parse(Console.ReadLine());

            double raspberriesPrice = berriesPrice / 2;
            double orangePrice = raspberriesPrice - (raspberriesPrice * 0.40);
            double banansPrice = raspberriesPrice - (raspberriesPrice * 0.80);


            double budget = berriesPrice * berriesQuantity + bananaQuantity * banansPrice + orangePrice * orangeQuantity + raspberriesPrice * raspberryQuantity;
            Console.WriteLine($"{budget:f2}");
        }
    }
}
