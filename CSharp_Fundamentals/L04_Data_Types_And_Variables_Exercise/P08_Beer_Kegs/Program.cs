using System;

namespace _08_Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            double highestVolume = 0.0;
            string biggest = string.Empty;
            for (int i = 0; i < n; i++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int hight = int.Parse(Console.ReadLine());

                double volume = Math.PI * Math.Pow(radius, 2) * hight;
                if (volume > highestVolume)
                {
                    highestVolume = volume;
                    biggest = model;
                }
            }
            Console.WriteLine(biggest);

        }
    }
}
