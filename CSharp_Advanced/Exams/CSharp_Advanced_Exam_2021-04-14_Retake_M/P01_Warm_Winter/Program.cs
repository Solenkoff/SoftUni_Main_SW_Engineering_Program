using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_Warm_Winter
{
    class Program
    {
        static void Main(string[] args)
        {


            Stack<int> hats = new Stack<int>(Console.ReadLine()
                                                      .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                                      .Select(int.Parse)
                                                      .ToArray());

            Queue<int> scarfs = new Queue<int>(Console.ReadLine()
                                                      .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                                      .Select(int.Parse)
                                                      .ToArray());




            List<int> sets = new List<int>();


            while (hats.Count > 0 && scarfs.Count > 0)
            {
                int currHat = hats.Pop();
                int currScarf = scarfs.Peek();

                if(currHat > currScarf)
                {
                    int setSum = currHat + currScarf;
                    sets.Add(setSum);
                    scarfs.Dequeue();
                }
                else if(currScarf > currHat)
                {
                    continue;
                }
                else if(currScarf == currHat)
                {
                    scarfs.Dequeue();
                    hats.Push(currHat + 1);
                }

            }

            int maxPriceSet = sets.OrderByDescending(x => x).FirstOrDefault();

            Console.WriteLine($"The most expensive set is: {maxPriceSet}");

            Console.WriteLine(string.Join(" ", sets));

        }
    }
}
