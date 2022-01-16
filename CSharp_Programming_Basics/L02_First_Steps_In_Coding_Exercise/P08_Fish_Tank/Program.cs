using System;

namespace _08_Fish_Tank
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double percentage = double.Parse(Console.ReadLine());
            double volumeL = lenght * width * height * 0.001;
            double litters = volumeL * (1 - percentage / 100);

            Console.WriteLine(litters);
        }
    }
}
