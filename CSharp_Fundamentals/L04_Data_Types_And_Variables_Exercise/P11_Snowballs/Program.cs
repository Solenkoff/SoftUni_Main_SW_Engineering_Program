using System;
using System.Numerics;

namespace _11_Snowballs_
{
    class Program
    {
        static void Main(string[] args)
        {

            int nSnowballs = int.Parse(Console.ReadLine());
            int snowballSnow = 0;
            int snowballTime = 0;
            int snowballQuality = 0;
            BigInteger highestSnowballValue = 0;
            for (int i = 0; i < nSnowballs; i++)
            {
                int currentSnowballSnow = int.Parse(Console.ReadLine());
                int currentSnowballTime = int.Parse(Console.ReadLine());
                int currentSnowballQuality = int.Parse(Console.ReadLine());

                BigInteger currantSnowballValue = BigInteger.Pow((currentSnowballSnow / currentSnowballTime), currentSnowballQuality);
                if (currantSnowballValue > highestSnowballValue)
                {
                    snowballSnow = currentSnowballSnow;
                    snowballTime = currentSnowballTime;
                    snowballQuality = currentSnowballQuality;
                    highestSnowballValue = currantSnowballValue;
                }
            }
            Console.WriteLine($"{snowballSnow} : {snowballTime} = {highestSnowballValue} ({snowballQuality})");

        }
    }
}
