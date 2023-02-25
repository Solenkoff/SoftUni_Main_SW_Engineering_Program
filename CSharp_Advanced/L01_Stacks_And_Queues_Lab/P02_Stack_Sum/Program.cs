using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _02_Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] inputArray = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var stack = new Stack<int>(inputArray);
                        
            while (true)
            {
                string[] commands = Console.ReadLine().ToLower().Split();
                
                if (commands[0] == "add")
                {
                    stack.Push(int.Parse(commands[1]));
                    stack.Push(int.Parse(commands[2]));
                }
                else if (commands[0] == "remove")
                {
                    int numsToRemove = int.Parse(commands[1]);
                    if (stack.Count >= numsToRemove)
                    {
                        for (int i = 0; i < numsToRemove; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
                else
                {
                    break;
                }
                
            }
         
            Console.WriteLine($"Sum: {stack.Sum()}");

        }
    }
}
