using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_Maximum_And_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {

            int nQueries = int.Parse(Console.ReadLine());

            var stack = new Stack<int>();

            for (int i = 0; i < nQueries; i++)
            {
                int[] queries = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (queries[0] == 1)
                {
                    stack.Push(queries[1]);
                }
                else if (queries[0] == 2)
                {
                    if(stack.Any())
                    {
                        stack.Pop();
                    }
                }
                else if (queries[0] == 3)
                {
                    if (stack.Any())
                    {
                        Console.WriteLine(stack.Max());
                    }                      
                }
                else if (queries[0] == 4)
                {
                    if (stack.Any())
                    {
                        Console.WriteLine(stack.Min());
                    }
                }

            }

            Console.WriteLine(string.Join(", ", stack));

        }
    }
}
