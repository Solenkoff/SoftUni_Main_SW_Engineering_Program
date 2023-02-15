using System;

namespace _01_Disneyland_s_Journey
{
    class Program
    {
        static void Main(string[] args)
        {

            double journeyCost = double.Parse(Console.ReadLine());
            int months = int.Parse(Console.ReadLine());

            double savedMoney = journeyCost * 0.25;

            for (int i = 2; i <= months; i++)
            {
                if (i % 2 == 1)
                {
                    savedMoney -= savedMoney * 0.16;
                }
                if (i % 4 == 0)
                {
                    savedMoney += savedMoney * 0.25;
                }

                savedMoney += journeyCost * 0.25;
            }

            if (savedMoney >= journeyCost)
            {
                Console.WriteLine($"Bravo! You can go to Disneyland and you will have " +
                    $"{savedMoney - journeyCost:f2}lv. for souvenirs.");
            }
            else
            {
                Console.WriteLine($"Sorry. You need {journeyCost - savedMoney:f2}lv. more.");
            }

        }
    }
}
