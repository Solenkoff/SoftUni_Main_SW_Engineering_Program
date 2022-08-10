using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_Train
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> wagons = Console.ReadLine()
                                      .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                      .Select(int.Parse)
                                      .ToList();

            int maxCapacity = int.Parse(Console.ReadLine());
            string input = string.Empty;

            while ((input = Console.ReadLine().ToLower()) != "end")
            {
                string[] comand = input.Split();
                if (comand[0] == "add")
                {
                    int nPassengers = int.Parse(comand[1]);
                    wagons.Add(nPassengers);
                }
                else
                {
                    int addPassengers = int.Parse(comand[0]);
                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if ((wagons[i] + addPassengers) <= maxCapacity)
                        {
                            wagons[i] += addPassengers;
                            break;
                        }
                    }
                    continue;
                }
            }

            Console.WriteLine(string.Join(' ', wagons));

        }
    }
}
