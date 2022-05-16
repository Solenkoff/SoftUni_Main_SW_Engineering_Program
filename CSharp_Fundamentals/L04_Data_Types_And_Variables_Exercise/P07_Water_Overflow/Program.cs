using System;

namespace _07_Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {

            int nLines = int.Parse(Console.ReadLine());

            int tankVolume = 255;
            for (int i = 0; i < nLines; i++)
            {
                int litersIn = int.Parse(Console.ReadLine());
                if (litersIn <= tankVolume)
                {
                    tankVolume -= litersIn;
                }
                else
                {
                    Console.WriteLine("Insufficient capacity!");
                }
            }
            Console.WriteLine($"{255 - tankVolume}");

        }
    }
}
