using System;
using System.Collections.Generic;


namespace _04_Orders
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, List<double>> products = new Dictionary<string, List<double>>();

            string input = Console.ReadLine();
            while (input != "buy")
            {
                string[] currentProduct = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string productName = currentProduct[0];
                double productPrice = double.Parse(currentProduct[1]);
                double productQuantity = double.Parse(currentProduct[2]);

                if (products.ContainsKey(productName))
                {
                    products[productName][0] = productPrice;
                    products[productName][1] += productQuantity;
                }
                else
                {
                    List<double> productData = new List<double> { productPrice, productQuantity };
                    products.Add(productName, productData);
                }

                input = Console.ReadLine();
            }

            foreach (var item in products)
            {
                double totalPrice = item.Value[0] * item.Value[1];
                Console.WriteLine($"{item.Key} -> {totalPrice:f2}");
            }

        }
    }
}
