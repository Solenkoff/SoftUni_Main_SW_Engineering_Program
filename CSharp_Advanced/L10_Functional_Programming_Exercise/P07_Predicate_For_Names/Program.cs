using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine()
                                          .Split(" ", StringSplitOptions.RemoveEmptyEntries)                                    
                                          .ToList();

           // names = names.Where(x => x.Length <= n).ToList();
           //  Or instead -> next 2 lines

            Func<string, int, bool> func = (name, length) => name.Length <= length;
            names = names.Where(name => func(name, n)).ToList();

            Action<List<string>> print = list => Console.WriteLine(string.Join(Environment.NewLine, list));

            print(names);

        }
    }
}
