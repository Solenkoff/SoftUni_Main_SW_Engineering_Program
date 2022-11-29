using System;

namespace _01_National_Court
{
    class Program
    {
        static void Main(string[] args)
        {

            int firstEmploeeE = int.Parse(Console.ReadLine());
            int secondEmploeeE = int.Parse(Console.ReadLine());
            int thirdEmploeeE = int.Parse(Console.ReadLine());
            int peopleCount = int.Parse(Console.ReadLine());

            int totalPerHour = firstEmploeeE + secondEmploeeE + thirdEmploeeE;

            int hours = 0;

            while (peopleCount > 0)
            {
                peopleCount -= totalPerHour;
                hours++;

                if (hours % 4 == 0)
                {
                    hours++;
                }

            }

            Console.WriteLine($"Time needed: {hours}h.");

        }
    }
}
