using System;
using System.Collections.Generic;
using System.Text;

namespace _09_Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {

            int manipulationsCount = int.Parse(Console.ReadLine());

            string result = string.Empty;

            Stack<string> stringStateStack = new Stack<string>();

            for (int i = 1; i <= manipulationsCount; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "1")
                {
                    stringStateStack.Push(result);
                    string stringToAppend = command[1];
                    result += stringToAppend;
                }
                else if (command[0] == "2")
                {
                    stringStateStack.Push(result);

                    int count = int.Parse(command[1]);
                    result = result.Substring(0, result.Length - count);

                }
                else if (command[0] == "3")
                {
                    int index = int.Parse(command[1]);

                    Console.WriteLine(result[index - 1]);
                }
                else if (command[0] == "4")
                {
                    if (stringStateStack.Count > 0)
                    {
                        result = stringStateStack.Pop();
                    }
                    else
                    {
                        result = string.Empty;
                    }
                }
            }

        }
    }
}
