using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02_Shopping_List
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> groceries = Console.ReadLine()
                                           .Split('!', StringSplitOptions.RemoveEmptyEntries)
                                           .ToList();

            string input = Console.ReadLine();

            while (input != "Go Shopping!")
            {
                string[] commands = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0];
                string item = commands[1];

                if (command == "Urgent")
                {

                    if (!groceries.Contains(item))
                    {
                        groceries.Insert(0, item);
                    }

                }
                else if (command == "Unnecessary")
                {

                    if (groceries.Contains(item))
                    {
                        groceries.Remove(item);
                    }

                }
                else if (command == "Correct")
                {
                    string newItem = commands[2];
                    if (groceries.Contains(item))
                    {
                        int index = groceries.IndexOf(item);
                        groceries.Remove(item);
                        groceries.Insert(index, newItem);

                    }

                }
                else if (command == "Rearrange")
                {
                    if (groceries.Contains(item))
                    {
                        groceries.Remove(item);
                        groceries.Add(item);
                    }

                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", groceries));

        }
    }
}
