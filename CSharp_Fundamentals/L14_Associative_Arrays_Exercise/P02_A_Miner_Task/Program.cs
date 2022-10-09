using System;
using System.Collections.Generic;

namespace _02_A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, int> output = new Dictionary<string, int>();

            string resource = Console.ReadLine();

            while (resource != "stop")
            {
                int quantity = int.Parse(Console.ReadLine());

                if (output.ContainsKey(resource))
                {
                    output[resource] += quantity;
                }
                else
                {
                    output.Add(resource, quantity);
                }

                resource = Console.ReadLine();
            }

            foreach (var item in output)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }

        }
    }
}
