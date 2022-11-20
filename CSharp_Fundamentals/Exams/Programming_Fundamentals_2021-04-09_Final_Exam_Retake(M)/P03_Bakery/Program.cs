using System;
using System.Collections.Generic;
using System.Linq;

namespace Bakery
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, int> goods = new Dictionary<string, int>();

            string input = Console.ReadLine();

            int soldGoods = 0;

            while (input != "Complete")
            {
                string[] parts = input.Split();

                string command = parts[0];
                int quantity = int.Parse(parts[1]);
                string foodName = parts[2];

                if(command == "Receive")
                {
                    if(!goods.ContainsKey(foodName) && quantity > 0)
                    {
                        goods.Add(foodName, quantity);
                    }
                }
                else if(command == "Sell")
                {
                    if(!goods.ContainsKey(foodName))
                    {
                        Console.WriteLine($"You do not have any {foodName}.");
                        
                    }
                    else if(goods[foodName] < quantity)
                    {
                        soldGoods += goods[foodName];
                        Console.WriteLine($"There aren't enough {foodName}. You sold the last {goods[foodName]} of them.");
                        goods.Remove(foodName);
                    }
                    else
                    {
                        goods[foodName] -= quantity;
                        soldGoods += quantity;
                        Console.WriteLine($"You sold {quantity} {foodName}.");

                        if(goods[foodName] == 0)
                        {
                            goods.Remove(foodName);
                        }
                    }               
                }

                input = Console.ReadLine();
            }

            var sortedGoods = goods.OrderBy(x => x.Key);

            foreach (var food in sortedGoods)
            {
                Console.WriteLine($"{food.Key}: {food.Value}");
            }

            Console.WriteLine($"All sold: {soldGoods} goods");
        }
    }
}
