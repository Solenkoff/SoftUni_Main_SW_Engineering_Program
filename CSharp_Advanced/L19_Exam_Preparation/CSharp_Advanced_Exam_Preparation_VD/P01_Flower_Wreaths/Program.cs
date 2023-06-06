using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_Flower_Wreaths
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] inputLilies = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[] inputRoses = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            Stack<int> lilies = new Stack<int>(inputLilies);
            Queue<int> roses = new Queue<int>(inputRoses);

            int wreathsCrafted = 0;
            int spareFlowers = 0;

            while (lilies.Any() && roses.Any())
            {
                int pickedLilies = lilies.Pop();
                int pikcedRoses = roses.Peek();

                int sum = pickedLilies + pikcedRoses;

                if (sum == 15)
                {
                    wreathsCrafted++;
                    roses.Dequeue();
                }
                else if (sum > 15)
                {
                    if (sum % 2 == 0)
                    {
                        lilies.Push(14 - pikcedRoses);
                        continue;
                    }
                    else
                    {
                        wreathsCrafted++;
                        roses.Dequeue();
                    }
                }
                else if (sum < 15)
                {
                    spareFlowers += sum;
                    roses.Dequeue();
                }

            }

            if (spareFlowers >= 15)
            {
                wreathsCrafted += spareFlowers / 15;
            }

            if (wreathsCrafted >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreathsCrafted} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreathsCrafted} wreaths more!");
            }
        }
    }
}
