using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {

            int food = int.Parse(Console.ReadLine());

            int[] input = Console.ReadLine()
                                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                 .Select(int.Parse)
                                 .ToArray();

            var orders = new Queue<int>(input);

            Console.WriteLine(orders.Max());

            while (orders.Any())
            {
                if (food >= orders.Peek())
                {
                    food -= orders.Dequeue();
                }
                else
                {
                    break;
                }
            }
            
            if (orders.Any())
            {
                Console.WriteLine($"Orders left: {string.Join(' ', orders)}");
            }
            else
            {
                Console.WriteLine("Orders complete");
            }

        }
    }
}
