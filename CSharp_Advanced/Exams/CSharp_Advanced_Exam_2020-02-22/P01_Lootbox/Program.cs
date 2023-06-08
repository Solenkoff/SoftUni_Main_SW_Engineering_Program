using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> firstBox = new Queue<int>(Console.ReadLine()
                                                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                                        .Select(int.Parse)
                                                        .ToArray());

            Stack<int> secondBox = new Stack<int>(Console.ReadLine()
                                                         .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                                         .Select(int.Parse)
                                                         .ToArray());

            int claimedItems = 0;

            while (firstBox.Count > 0 && secondBox.Count > 0)
            {
                int firstNum = firstBox.Peek();
                int secondNum = secondBox.Pop();

                int sum = firstNum + secondNum;

                if(sum % 2 == 0)
                {
                    firstBox.Dequeue();
                    claimedItems += sum;
                }
                else
                {
                    firstBox.Enqueue(secondNum);
                }
            }

            if(firstBox.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if(claimedItems >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimedItems}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimedItems}");
            }
        }
    }
}
