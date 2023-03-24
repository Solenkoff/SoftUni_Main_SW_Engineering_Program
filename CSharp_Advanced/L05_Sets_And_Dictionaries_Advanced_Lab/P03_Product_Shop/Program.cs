using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> shops = new Dictionary<string, Dictionary<string, double>>();

            string input = Console.ReadLine();

            while (input != "Revision")
            {
                string[] shopData = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string shopName = shopData[0];
                string product = shopData[1];
                double price = double.Parse(shopData[2]);

                if (!shops.ContainsKey(shopName))
                {
                    shops.Add(shopName, new Dictionary<string, double>());
                }

                if (!shops[shopName].ContainsKey(product))
                {
                    shops[shopName].Add(product, price);
                }

                input = Console.ReadLine();
            }

            foreach (var shop in shops.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }

        }
    }
}
