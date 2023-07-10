using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P01_Blacksmith
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<int, string> swords = new Dictionary<int, string>()
            {
                { 70, "Gladius" },
                { 80, "Shamshir" },
                { 90, "Katana" },
                { 110, "Sabre" },
                { 150, "Broadsword" }
            };

            Dictionary<string, int> forgedSwords = new Dictionary<string, int>()
            {
                { "Gladius", 0 },
                { "Shamshir", 0 },
                { "Katana", 0 },
                { "Sabre", 0 },
                { "Broadsword", 0 }
            };

            Queue<int> steel = new Queue<int>(Console.ReadLine()
                                                           .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                                           .Select(int.Parse));
            Stack<int> carbon = new Stack<int>(Console.ReadLine()
                                                               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                                               .Select(int.Parse));

            while (steel.Any() && carbon.Any())
            {
                int currSteel = steel.Dequeue();

                int currCarbon = carbon.Pop();

                int sum = currSteel + currCarbon;

                if (swords.ContainsKey(sum))
                {
                    forgedSwords[swords[sum]]++;

                    continue;
                }

                carbon.Push(currCarbon + 5);
            }

            int totalForgedSwords = forgedSwords.Values.Sum();

            if (forgedSwords.Any(x => x.Value > 0))
            {
                Console.WriteLine($"You have forged {totalForgedSwords} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }

            if (steel.Any())
            {
                Console.WriteLine($"Steel left: " + string.Join(", ", steel));
            }
            else
            {
                Console.WriteLine("Steel left: none");
            }

            if (carbon.Any())
            {
                Console.WriteLine($"Carbon left: " + string.Join(", ", carbon));
            }
            else
            {
                Console.WriteLine("Carbon left: none");
            }


            foreach (var sword in forgedSwords.Where(x => x.Value > 0).OrderBy(x => x.Key))
            {
                Console.WriteLine($"{sword.Key}: {sword.Value}");
            }

        }
    }
}
