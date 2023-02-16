using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_List_Of_Coffees_In_Stock
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> coffees = Console.ReadLine()
                                          .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                          .ToList();
            int nCommands = int.Parse(Console.ReadLine());


            for (int i = 0; i < nCommands; i++)
            {
                string[] commands = Console.ReadLine()
                                           .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0];

                if (command == "Include")
                {
                    string typeCoffee = commands[1];
                    coffees.Add(typeCoffee);
                }
                else if (command == "Remove")
                {
                    string firstOrLast = commands[1];
                    int nCoffees = int.Parse(commands[2]);

                    if (nCoffees <= coffees.Count && nCoffees > 0)
                    {
                        if (firstOrLast == "first")
                        {
                            coffees.RemoveRange(0, nCoffees);
                        }
                        else if (firstOrLast == "last")
                        {
                            coffees.RemoveRange(coffees.Count - nCoffees, nCoffees);
                        }
                    }
                }
                else if (command == "Prefer")
                {
                    int indexOne = int.Parse(commands[1]);
                    int indexTwo = int.Parse(commands[2]);

                    if (indexOne >= 0 && indexOne < coffees.Count && indexTwo >= 0 && indexTwo < coffees.Count)
                    {
                        string one = coffees[indexOne];
                        string two = coffees[indexTwo];

                        coffees[indexOne] = two;
                        coffees[indexTwo] = one;
                    }

                }
                else if (command == "Reverse")
                {
                    coffees.Reverse();
                }

            }

            Console.WriteLine("Coffees:");
            Console.WriteLine(string.Join(" ", coffees));

        }
    }
}
