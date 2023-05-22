using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_Knights_Of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            List<string> newNames = names.Select(name => $"Sir {name}").ToList();

            Action<List<string>> printNames = names => Console.WriteLine(string.Join(Environment.NewLine, names));

            printNames(newNames);

        }
    }
}
