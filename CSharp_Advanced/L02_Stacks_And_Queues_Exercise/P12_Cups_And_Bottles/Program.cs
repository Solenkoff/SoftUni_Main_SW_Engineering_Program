using System;
using System.Collections.Generic;
using System.Linq;

namespace _12_Cups_And_Bottles_
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] cupsInput = Console.ReadLine()
                                     .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                     .Select(int.Parse)
                                     .ToArray();
            int[] bottlesInput = Console.ReadLine()
                                     .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                     .Select(int.Parse)
                                     .ToArray();

            var cups = new Queue<int>(cupsInput);
            var bottles= new Stack<int>(bottlesInput);

            int wastedWater = 0;

            while (cups.Any() && bottles.Any())
            {
                int currCup = cups.Peek();
                int currBottle = bottles.Pop();

                if (currCup <= currBottle)
                {
                    wastedWater += currBottle - currCup;
                    cups.Dequeue();
                }
                else
                {
                    while (true)
                    {
                        currCup -= currBottle;
                        currBottle = bottles.Pop();

                        if (currCup <= currBottle)
                        {
                            wastedWater += currBottle - currCup;
                            cups.Dequeue();
                            break;
                        }
                    }
                }
            }
            
            if (cups.Any())
            {
                Console.WriteLine($"Cups: {string.Join(' ', cups)}");
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }
            else if (bottles.Any())
            {
                Console.WriteLine($"Bottles: {string.Join(' ', bottles)}");
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }
            
        }
    }
}
