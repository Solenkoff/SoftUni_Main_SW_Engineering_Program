using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_Masterchef
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<int, string> dishes = new Dictionary<int, string>()
            {
                { 150, "Dipping sauce" },
                { 250, "Green salad" },
                { 300, "Chocolate cake" },
                { 400, "Lobster" }
            };

            Dictionary<string, int> cookedDishes = new Dictionary<string, int>()
            {
                { "Dipping sauce", 0 },
                { "Green salad", 0 },
                { "Chocolate cake", 0 },
                { "Lobster", 0 }
            };

            Queue<int> ingredients = new Queue<int>(Console.ReadLine()
                                                           .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                                           .Select(int.Parse));
            Stack<int> freshnessLevels = new Stack<int>(Console.ReadLine()
                                                               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                                               .Select(int.Parse));

            while (ingredients.Any() && freshnessLevels.Any())
            {
                int ingredient = ingredients.Dequeue();
                
                if (ingredient == 0)
                {
                    continue;
                }

                int freshness = freshnessLevels.Pop();

                int sum = ingredient * freshness;

                if (dishes.ContainsKey(sum))
                {                   
                    cookedDishes[dishes[sum]]++;

                    continue;
                }             

                ingredients.Enqueue(ingredient + 5);
            }

            if (cookedDishes.All(x => x.Value > 0))
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }        

            if (ingredients.Any())
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }

            foreach (var dish in cookedDishes.Where(x => x.Value > 0).OrderBy(x => x.Key))
            {
                Console.WriteLine($" # {dish.Key} --> {dish.Value}");
            }

        }
    }
}
