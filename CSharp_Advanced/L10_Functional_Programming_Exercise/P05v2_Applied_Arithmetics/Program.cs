using System;
using System.Collections.Generic;
using System.Linq;

namespace _05v2_Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, Func<int, int>> arithmeticFunctions = new Dictionary<string, Func<int, int>>()
            {
                { "add", num => num + 1 },
                { "multiply", num => num * 2 },
                { "subtract", num => num - 1 }
            };


            List<int> numbers = Console.ReadLine()
                                      .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                      .Select(int.Parse)
                                      .ToList();

            string command = Console.ReadLine();

            Action<List<int>> print = nums => Console.WriteLine(string.Join(" ", nums));

            while (command != "end")
            {

                if (arithmeticFunctions.ContainsKey(command))
                {
                    Func<int, int> func = arithmeticFunctions[command];
                    numbers = numbers.Select(func).ToList();
                }
                else if (command == "print")
                {
                    print(numbers);
                }

                command = Console.ReadLine();

            }

        }
    }   
}
