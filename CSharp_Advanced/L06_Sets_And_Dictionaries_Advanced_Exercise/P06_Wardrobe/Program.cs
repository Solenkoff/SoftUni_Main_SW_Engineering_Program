using System;
using System.Collections.Generic;

namespace _06_Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> clothes = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] clothesData = Console.ReadLine().Split(" -> ");
                string colour = clothesData[0];
                string[] items = clothesData[1].Split(',');

                foreach (var item in items)
                {
                    if (!clothes.ContainsKey(colour))
                    {
                        clothes.Add(colour, new Dictionary<string, int>());
                    }
                    if (!clothes[colour].ContainsKey(item))
                    {
                        clothes[colour].Add(item, 0);
                    }

                    clothes[colour][item]++;
                }
                
            }

            string[] itemData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string colourQuest = itemData[0];
            string itemQuest = itemData[1];

            foreach (var colour in clothes)
            {
                Console.WriteLine($"{colour.Key} clothes:");

                foreach (var item in colour.Value)
                {
                    if(item.Key == itemQuest && colour.Key == colourQuest)
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value}");
                    }
                    
                }
            }

        }
    }
}
