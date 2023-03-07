using System;
using System.Collections.Generic;
using System.Linq;

namespace _08_Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();

            var stack = new Stack<char>();

            bool isBalanced = true;

            foreach (var ch in input)
            {
                if (ch == '(' || ch == '{' || ch == '[')
                {
                    stack.Push(ch);
                }
                else if (ch == ')' || ch == '}' || ch == ']')
                {
                    if (!stack.Any())
                    {
                        isBalanced = false;
                        break;
                    }
                    else
                    {
                        char lastChar = stack.Pop();
                        if (ch == ')' && lastChar == '(' || 
                            ch == '}' && lastChar == '{' || 
                            ch == ']' && lastChar == '[')
                        {
                            continue;
                        }
                        else
                        {
                            isBalanced = false;
                            break;
                        }

                    }
                }
            }
            
          //if (stack.Any())
          //{
          //    isBalanced = false;
          //}

            if(isBalanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }

        }     
    }
}
