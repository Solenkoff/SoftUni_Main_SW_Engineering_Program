using System;
using System.Collections.Generic;

namespace _06_Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = new Queue<string>();

            string name = Console.ReadLine();

            while (name != "End")
            {
                if (name == "Paid")
                {
                    foreach (var item in names)
                    {
                        Console.WriteLine(item);
                    }
                    names.Clear();
                }
                else
                {
                    names.Enqueue(name);
                }

                name = Console.ReadLine();
            }

            Console.WriteLine($"{names.Count} people remaining.");

        }
    }
}
