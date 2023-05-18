using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_Generic_Swap_Method_Integer
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Box<int>> boxes = new List<Box<int>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Box<int> currBox = new Box<int>(int.Parse(Console.ReadLine()));
                boxes.Add(currBox);
            }

            int[] indexes = Console.ReadLine()
                                   .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                   .Select(int.Parse)
                                   .ToArray();

            int indexOne = indexes[0];
            int indexTwo = indexes[1];

            SwapBoxes(boxes, indexOne, indexTwo);

            foreach (var box in boxes)
            {
                Console.WriteLine(box);
            }
        }


        private static void SwapBoxes<T>(List<Box<T>> boxes, int indexOne, int indexTwo)
        {
            Box<T> tempBox = boxes[indexOne];
            boxes[indexOne] = boxes[indexTwo];
            boxes[indexTwo] = tempBox;
        }

    }
}
