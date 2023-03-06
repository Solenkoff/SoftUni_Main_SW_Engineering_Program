using System;
using System.Collections.Generic;
using System.Linq;

namespace _05v2_Fashion_Boutique
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

            int currentRackCapacity = rackCapacity;
            int racks = 1;

            while (clothes.Any())
            {
                int onePiece = clothes.Pop();
                currentRackCapacity -= onePiece;

                if (currentRackCapacity < 0)
                {
                    racks++;
                    currentRackCapacity = rackCapacity - onePiece;
                    //currentRackCapacity -= onePiece;
                }
            }

            Console.WriteLine(racks);

        }
    }
}
