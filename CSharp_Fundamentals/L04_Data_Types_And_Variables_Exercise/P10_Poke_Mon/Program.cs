using System;

namespace _10_Poke_Mon_
{
    class Program
    {
        static void Main(string[] args)
        {

            int powerNStartValue = int.Parse(Console.ReadLine());
            int distanceM = int.Parse(Console.ReadLine());
            int exhaustionY = int.Parse(Console.ReadLine());

            int powerN = powerNStartValue;
            int targets = 0;

            while (powerN >= distanceM)
            {
                powerN -= distanceM;
                targets++;
                if ((powerN == powerNStartValue / 2.0) && (exhaustionY != 0))
                {
                    powerN /= exhaustionY;
                }
            }
            Console.WriteLine(powerN);
            Console.WriteLine(targets);

        }
    }
}
