using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_Heart_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> neighborhood = Console.ReadLine()
                                           .Split('@', StringSplitOptions.RemoveEmptyEntries)
                                           .Select(int.Parse)
                                           .ToList();

            string input = Console.ReadLine();
            int lastIndex = 0;
            int currentIndex = 0;

            while (input != "Love!")
            {
                string[] commands = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int jumpLength = int.Parse(commands[1]);


                if (jumpLength > neighborhood.Count - 1 - lastIndex)
                {
                    currentIndex = 0;
                }
                else
                {
                    currentIndex = lastIndex + jumpLength;
                }

                if (neighborhood[currentIndex] == 0)
                {
                    Console.WriteLine($"Place {currentIndex} already had Valentine's day.");
                    lastIndex = currentIndex;
                }
                else
                {
                    neighborhood[currentIndex] -= 2;
                    if (neighborhood[currentIndex] == 0)
                    {
                        Console.WriteLine($"Place {currentIndex} has Valentine's day.");
                    }
                    lastIndex = currentIndex;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Cupid's last position was {currentIndex}.");

            int counter = 0;
            foreach (var item in neighborhood)
            {
                if (item == 0)
                {
                    counter++;
                }
            }

            if (counter == neighborhood.Count)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Cupid has failed {neighborhood.Count - counter} places.");
            }

        }
    }
}
