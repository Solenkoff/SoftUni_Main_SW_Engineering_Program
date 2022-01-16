using System;

namespace _08_Pet_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            int dogsNum = int.Parse(Console.ReadLine());
            int otherAnimalNum = int.Parse(Console.ReadLine());

            double dogFoodPrice = 2.50;
            double otherAnimalFoodPrice = 4.00;
            double finalAmount = dogFoodPrice * dogsNum + otherAnimalFoodPrice * otherAnimalNum;

            Console.WriteLine($"{finalAmount} lv.");
        }
    }
}
