namespace P04_List_Of_Products
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            List<string> products = new List<string>(n);

            for (int i = 0; i < n; i++)
            {
                products.Add(Console.ReadLine());
            }

            products.Sort();
            int count = 1;
            foreach (var product in products)
            {
                Console.WriteLine($"{count++}.{product}");
            }

        }
    }
}
