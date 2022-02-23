using System;

namespace _09_Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            int volume = lenght * width * height;
            bool hasSpace = true;

            string command = Console.ReadLine();
            while (hasSpace && command != "Done")
            {
                int box = int.Parse(command);
                volume -= box;
                if (volume < 0)
                {
                    hasSpace = false;
                    break;
                }
                command = Console.ReadLine();
            }
            if (hasSpace)
            {
                Console.WriteLine($"{volume} Cubic meters left.");
            }
            else
            {
                Console.WriteLine($"No more free space! You need {Math.Abs(volume)} Cubic meters more.");
            }
        }
    }
}
