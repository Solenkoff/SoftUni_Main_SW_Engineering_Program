using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_Action_Print
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Action<string[]> printNames = name => Console.WriteLine(string.Join(Environment.NewLine, name));

            printNames(names);

        }
    }
}
