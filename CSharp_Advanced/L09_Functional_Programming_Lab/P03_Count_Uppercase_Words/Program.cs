using System;
using System.Linq;

namespace _03_Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            // var input = Console.ReadLine()
            //                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            //                    .Where(s => s[0] == s.ToUpper()[0])
            //                    .ToArray();
            //
            // Console.WriteLine(string.Join("\n", input));

            Func<string, bool> upperChecker = s => s[0] == s.ToUpper()[0];

            var input = Console.ReadLine()
                               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                               .Where(upperChecker)
                               .ToArray();

            Console.WriteLine(string.Join("\n", input));

        }
    }
}
