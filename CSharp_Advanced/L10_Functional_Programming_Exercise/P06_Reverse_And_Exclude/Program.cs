using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> numbers = Console.ReadLine()
                                      .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                      .Select(int.Parse)
                                      .Reverse()
                                      .ToList();

            int divisor = int.Parse(Console.ReadLine());

            List<int> newList = new List<int>();

            Func<List<int>, List<int>> divisibles = nums =>
            {            
                foreach (var num in nums)
                {
                    if(num % divisor != 0)
                    {
                        newList.Add(num);
                    }
                }
                return newList;
            };

            numbers = divisibles(numbers);

            Action<List<int>> print = list => Console.WriteLine(string.Join(" ", list));

            print(numbers);
     
        }
    }
}
