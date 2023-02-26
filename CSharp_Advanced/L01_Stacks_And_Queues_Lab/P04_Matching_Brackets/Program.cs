using System;
using System.Collections.Generic;

namespace _04_Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();

            var parenthesis = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    parenthesis.Push(i);
                }
                else if (input[i] == ')')
                {
                    int indexBeginning = parenthesis.Pop();
                    Console.WriteLine(input.Substring(indexBeginning, i - indexBeginning + 1));
                }
            }
       
        }
    }
}
