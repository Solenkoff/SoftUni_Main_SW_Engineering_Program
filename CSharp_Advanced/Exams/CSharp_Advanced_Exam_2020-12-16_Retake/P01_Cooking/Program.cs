using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_Cooking
{
    class Program
    {
        static void Main(string[] args)
        {

            Queue<int> liquids = new Queue<int>(Console.ReadLine()
                                                      .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                                      .Select(int.Parse)
                                                      .ToArray());

            Stack<int> ingredients = new Stack<int>(Console.ReadLine()
                                                      .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                                      .Select(int.Parse)
                                                      .ToArray());


            int bread = 0;
            int cake = 0;
            int pastry = 0;
            int fruitPie = 0;

            while (liquids.Count > 0 && ingredients.Count > 0)
            {
                int currLiq = liquids.Dequeue();
                int currIngr = ingredients.Pop();
                int sum = currLiq + currIngr;

                if (sum == 25)
                {
                    bread++;
                }
                else if (sum == 50)
                {
                    cake++;
                }
                else if (sum == 75)
                {
                    pastry++;
                }
                else if (sum == 100)
                {
                    fruitPie++;
                }
                else
                {
                    ingredients.Push(currIngr + 3);
                }
            }

            

            if(bread >= 1 && cake >= 1 && pastry >= 1 && fruitPie >= 1)
            {
                Console.WriteLine($"Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine($"Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if(liquids.Count == 0)
            {
                Console.WriteLine("Liquids left: none");
            }
            else
            {
                Console.WriteLine($"Liquids left: " + string.Join(", ", liquids));
            }

            if (ingredients.Count == 0)
            {
                Console.WriteLine("Ingredients left: none");
            }
            else
            {
                Console.WriteLine($"Ingredients left: " + string.Join(", ", ingredients));
            }

            Console.WriteLine($"Bread: {bread}");
            Console.WriteLine($"Cake: {cake}");
            Console.WriteLine($"Fruit Pie: {fruitPie}");
            Console.WriteLine($"Pastry: {pastry}");
        }
    }
}
