using System;

namespace P10_Rage_Expenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int nLostGames = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            double rageExpences = (nLostGames / 2 * headsetPrice) + (nLostGames / 3 * mousePrice)
                + (nLostGames / 6 * keyboardPrice) + (nLostGames / 12 * displayPrice);

            Console.WriteLine($"Rage expenses: {rageExpences:f2} lv.");
        }
    }
}
