﻿using System;
using System.Collections.Generic;

namespace P02_Shopping_Spree
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            var people = new Dictionary<string, Person>();
            var products = new Dictionary<string, Product>();

            try
            {
                people = ReadPeople();
                products = ReadProducts();
            }
            catch (ArgumentException ex)
            {

                Console.WriteLine(ex.Message);
                return;
            }

            while (true)
            {
                var line = Console.ReadLine();

                if (line == "END")
                {
                    break;
                }

                var parts = line.Split();

                var personName = parts[0];
                var productName = parts[1];

                var person = people[personName];
                var product = products[productName];

                try
                {
                    person.AddProduct(product);

                    Console.WriteLine($"{personName} bought {productName}");
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

            }

            foreach (var person in people.Values)
            {
                Console.WriteLine(person);
            }

        }


        private static Dictionary<string, Person> ReadPeople()
        {
            var result = new Dictionary<string, Person>();
            var parts = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            foreach (var part in parts)
            {
                var personData = part.Split('=');
                var name = personData[0];
                var money = decimal.Parse(personData[1]);

                result[name] = new Person(name, money);
            }

            return result;
        }


        private static Dictionary<string, Product> ReadProducts()
        {
            var result = new Dictionary<string, Product>();
            var parts = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            foreach (var part in parts)
            {
                var productData = part.Split('=');
                var pruductName = productData[0];
                var cost = decimal.Parse(productData[1]);

                result[pruductName] = new Product(pruductName, cost);
            }

            return result;
        }

    }
}
