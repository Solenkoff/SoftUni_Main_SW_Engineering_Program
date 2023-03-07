using System;
using System.Collections.Generic;

namespace _08v2_Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();


            if (IsWellFormatted(input))
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }

        }


        private static bool IsWellFormatted(string line)
        {
            Stack<char> lastOpen = new Stack<char>();
            foreach (var c in line)
            {
                switch (c)
                {
                    case ')':
                        if (lastOpen.Count == 0 || lastOpen.Pop() != '(') return false;
                        break;
                    case ']':
                        if (lastOpen.Count == 0 || lastOpen.Pop() != '[') return false;
                        break;
                    case '}':
                        if (lastOpen.Count == 0 || lastOpen.Pop() != '{') return false;
                        break;
                    case '(': lastOpen.Push(c); break;
                    case '[': lastOpen.Push(c); break;
                    case '{': lastOpen.Push(c); break;
                }
            }
            if (lastOpen.Count == 0) return true;
            else return false;

        }
    }
}
