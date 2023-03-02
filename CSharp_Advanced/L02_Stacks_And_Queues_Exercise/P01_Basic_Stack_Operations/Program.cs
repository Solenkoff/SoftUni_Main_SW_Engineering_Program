using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_Basic_Stack_Operations
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

            Stack<int> playStack = new Stack<int>();

            for (int i = 0; i < nElementsIn; i++)
            {
                playStack.Push(elementsIn[i]);
            }

            if (nElementsOut > nElementsIn)
            {
                nElementsOut = nElementsIn;
            }

            for (int i = 0; i < nElementsOut; i++)
            {
                playStack.Pop();
            }

            if (!playStack.Any())
            {
                Console.WriteLine(0);
            }
            else if (playStack.Contains(elementX))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(playStack.Min());
            }
            
        }
    }
}
