using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] input = Console.ReadLine()
                                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                 .Select(int.Parse)
                                 .ToArray();

            int rackCapacity = int.Parse(Console.ReadLine());

            var clothes = new Stack<int>(input);

            int racks = 0;
            int sum = 0;

            while (clothes.Any())
            {
                if (sum + clothes.Peek() < rackCapacity)
                {
                    sum += clothes.Pop();
                }
                else if(sum + clothes.Peek() == rackCapacity)
                {
                    clothes.Pop();
                    racks++;
                    sum = 0;
                }
                else if(sum + clothes.Peek() > rackCapacity)
                {
                    racks++;
                    sum = 0;
                }
            }

            if (sum != 0)
            {
                racks++;
            }

            Console.WriteLine(racks);

        }
    }
}
