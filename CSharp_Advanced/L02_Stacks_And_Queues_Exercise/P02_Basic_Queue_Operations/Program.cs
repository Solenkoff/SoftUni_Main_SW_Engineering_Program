using System;
using System.Collections.Generic;
using System.Linq;


namespace _02_Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] data = Console.ReadLine()
                               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse)
                               .ToArray();

            int nElementsIn = data[0];
            int nElementsOut = data[1];
            int elementX = data[2];

            int[] elementsIn = Console.ReadLine()
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();

            Queue<int> playQueue = new Queue<int>();

            for (int i = 0; i < nElementsIn; i++)
            {
                playQueue.Enqueue(elementsIn[i]);
            }

            if (nElementsOut > nElementsIn)
            {
                nElementsOut = nElementsIn;
            }

            for (int i = 0; i < nElementsOut; i++)
            {
                playQueue.Dequeue();
            }

            if (!playQueue.Any())
            {
                Console.WriteLine(0);
            }
            else if (playQueue.Contains(elementX))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(playQueue.Min());
            }

        }
    }
}
