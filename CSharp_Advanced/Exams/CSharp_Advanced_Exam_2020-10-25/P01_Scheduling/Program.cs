using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01_Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] tasksData = Console.ReadLine()
                                     .Split(", ")
                                     .Select(int.Parse)
                                     .ToArray();
            Stack<int> tasks = new Stack<int>(tasksData);
           
            int[] threadsData = Console.ReadLine()
                                     .Split(" ")
                                     .Select(int.Parse)
                                     .ToArray();

            Queue<int> threads = new Queue<int>(threadsData);

            int taskToKill = int.Parse(Console.ReadLine());


            while (true)
            {
                int currThread = threads.Peek();
                int currTask = tasks.Peek();

                if (currTask == taskToKill)
                {
                    Console.WriteLine($"Thread with value {currThread} killed task {currTask}");
                    break;
                }
                else
                {
                    if(currThread >= currTask)
                    {                       
                        tasks.Pop();
                    }

                    threads.Dequeue();
                }
            }

            Console.WriteLine(string.Join(" ", threads));
         
        }
    }
}
