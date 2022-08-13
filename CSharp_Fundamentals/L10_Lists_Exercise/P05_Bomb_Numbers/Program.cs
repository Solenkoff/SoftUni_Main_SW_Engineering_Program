using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> numbers = Console.ReadLine()
                                      .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                      .Select(int.Parse)
                                      .ToList();
            List<int> bomb = Console.ReadLine()
                                       .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                       .Select(int.Parse)
                                       .ToList();
            int bombNumber = bomb[0];
            int bombPower = bomb[1];

            for (int i = 0; i < numbers.Count; i++)
            {
                int currentNumber = numbers[i];

                if (currentNumber == bombNumber)
                {
                    int startIndex = i - bombPower;
                    int endIndex = i + bombPower;

                    if (startIndex < 0)
                    {
                        startIndex = 0;
                    }
                    if (endIndex > numbers.Count - 1)
                    {
                        endIndex = numbers.Count - 1;
                    }

                    int rangeToRemove = endIndex - startIndex + 1;
                    numbers.RemoveRange(startIndex, rangeToRemove);

                    i = startIndex - 1;
                }
            }

            int sumOfRemaining = numbers.Sum();
            Console.WriteLine(sumOfRemaining);

        }
    }
}
