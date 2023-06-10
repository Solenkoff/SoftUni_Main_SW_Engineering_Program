using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] bombEffectsInput = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[] bombCasingInput = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            Queue<int> effects = new Queue<int>(bombEffectsInput);
            Stack<int> casings = new Stack<int>(bombCasingInput);

            SortedDictionary<string, int> bombs = new SortedDictionary<string, int>
            {
                { "Datura Bombs", 0},
                { "Cherry Bombs", 0},
                { "Smoke Decoy Bombs", 0}
            };

            while (effects.Count > 0 && casings.Count > 0 && bombs.Values.Any(x => x < 3))
            {
                int tryEffect = effects.Peek();
                int tryCasing = casings.Pop();

                int sum = tryEffect + tryCasing;

                if (sum == 40)
                {
                    bombs["Datura Bombs"]++;

                }
                else if (sum == 60)
                {
                    bombs["Cherry Bombs"]++;
                }
                else if (sum == 120)
                {
                    bombs["Smoke Decoy Bombs"]++;
                }
                else
                {
                    casings.Push(tryCasing - 5);
                    continue;
                }

                effects.Dequeue();
            }

            if (bombs.Values.All(x => x >= 3))
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (effects.Count > 0)
            {
                Console.WriteLine($"Bomb Effects: " + string.Join(", ", effects));
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }

            if (casings.Count > 0)
            {
                Console.WriteLine($"Bomb Casings: " + string.Join(", ", casings));
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }


            foreach (var item in bombs)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

        }
    }
}
