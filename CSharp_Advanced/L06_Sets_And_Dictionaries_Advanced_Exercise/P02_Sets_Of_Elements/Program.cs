using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_Sets_Of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] setsLength = Console.ReadLine()
                                      .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                      .Select(int.Parse)
                                      .ToArray();

            HashSet<int> setOne = new HashSet<int>();
            HashSet<int> setTwo = new HashSet<int>();

            int setOneLenght = setsLength[0];
            int setTwoLenght = setsLength[1];
            int totalLenght = setOneLenght + setTwoLenght;

            for (int i = 0; i < setOneLenght; i++)
            {
                int numOne = int.Parse(Console.ReadLine());
                setOne.Add(numOne);
            }
            for (int i = 0; i < setTwoLenght; i++)
            {
                int numTwo = int.Parse(Console.ReadLine());
                setTwo.Add(numTwo);
            }

            foreach (var item in setOne)
            {
                if(setTwo.Contains(item))
                {
                    Console.Write(item + " ");
                }
            }

        }
    }
}
