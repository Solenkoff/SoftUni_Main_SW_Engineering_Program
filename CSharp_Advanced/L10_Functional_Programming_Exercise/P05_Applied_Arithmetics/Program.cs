using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> numbers = Console.ReadLine()
                                       .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                       .Select(int.Parse)
                                       .ToList();

            string input = Console.ReadLine();

            while (input != "end")
            {
                Func<int, int> arithmetics = num => num;
                Action<List<int>> print = nums => Console.WriteLine(string.Join(" ", nums));

                if (input == "add")
                {
                    arithmetics = num => num + 1;
                    numbers = numbers.Select(n => arithmetics(n)).ToList();
                }
                else if (input == "multiply")
                {
                    arithmetics = num => num * 2;
                    numbers = numbers.Select(n => arithmetics(n)).ToList();
                }
                else if (input == "subtract")
                {
                    arithmetics = num => num - 1;
                    numbers = numbers.Select(n => arithmetics(n)).ToList();
                }
                else if (input == "print")
                {
                    print(numbers);
                }

                input = Console.ReadLine();

            }

        }
    }
}
