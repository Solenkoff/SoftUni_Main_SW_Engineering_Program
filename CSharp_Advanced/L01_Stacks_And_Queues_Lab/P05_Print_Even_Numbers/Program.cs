using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] input = Console.ReadLine()
                                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                 .Select(int.Parse)
                                 .ToArray();

            var queueOfIntegers = new Queue<int>(input);

            var evenIntegers = new List<int>();

            while (queueOfIntegers.Any())
            {
                if (queueOfIntegers.Peek() % 2 == 0)
                {
                    evenIntegers.Add(queueOfIntegers.Dequeue());
                }
                else
                {
                    queueOfIntegers.Dequeue();
                }
            }
                          
            Console.WriteLine(string.Join(", ", evenIntegers));

        }
    }
}
