using System;

namespace _06_Godzilla_Vs._Kong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int statistsNum = int.Parse(Console.ReadLine());
            double priceClothesperStat = double.Parse(Console.ReadLine());


            double finalStatistsClothesprice = statistsNum * priceClothesperStat;
            budget -= budget * 0.10;
            if (statistsNum > 150)
            {
                finalStatistsClothesprice -= finalStatistsClothesprice * 0.10;
            }
            budget -= finalStatistsClothesprice;

            if (budget >= 0)
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {budget:f2} leva left.");
            }
            else
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {Math.Abs(budget):f2} leva more.");
            }
        }
    }
}
