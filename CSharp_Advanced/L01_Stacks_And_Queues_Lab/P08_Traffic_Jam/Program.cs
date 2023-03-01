using System;
using System.Collections.Generic;

namespace _08_Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {

            int carLimit = int.Parse(Console.ReadLine());

            var cars = new Queue<string>();
            int nCars = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end") 
                {
                    break;
                }
                else if (input == "green")
                {
                    if (carLimit > cars.Count)
                    {
                        carLimit = cars.Count;
                    }
                    for (int i = 0; i < carLimit; i++)
                    {
                        Console.WriteLine($"{cars.Dequeue()} passed!");
                        nCars++;
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }

            }

            Console.WriteLine($"{nCars} cars passed the crossroads.");

        }
    }
}
