using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var orderedStack = new Stack<string>(input.Reverse());
          
            while (orderedStack.Count > 1)
            {
                int elementOne = int.Parse(orderedStack.Pop());
                string operation = orderedStack.Pop();
                int elementTwo = int.Parse(orderedStack.Pop());

                if (operation == "+")
                {
                    orderedStack.Push((elementOne + elementTwo).ToString());
                }
                else if (operation == "-")
                {
                    orderedStack.Push((elementOne - elementTwo).ToString());
                }
            }

            Console.WriteLine(orderedStack.Pop());

        }
    }
}
