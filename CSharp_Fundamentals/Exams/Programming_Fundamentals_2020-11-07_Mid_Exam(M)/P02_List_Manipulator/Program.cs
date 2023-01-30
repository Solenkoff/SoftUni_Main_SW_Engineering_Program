using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq

namespace _02_List_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> friends = Console.ReadLine()
                                         .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                         .ToList();

            string input = Console.ReadLine();
            int allBlacklisted = 0;
            int allLostNames = 0;

            while (input != "Report")
            {
                string[] comandArg = input.Split();
                string comand = comandArg[0];

                if (comand == "Blacklist")
                {
                    string guestName = comandArg[1];
                    if (friends.Contains(guestName))
                    {

                        int index = friends.IndexOf(guestName);
                        Console.WriteLine($"{guestName} was blacklisted.");
                        friends[index] = "Blacklisted";
                        allBlacklisted++;
                    }
                    else
                    {
                        Console.WriteLine($"{guestName} was not found.");
                    }
                }
                else if (comand == "Error")
                {
                    int index = int.Parse(comandArg[1]);
                    if (friends[index] != "Blacklisted" && friends[index] != "Lost")
                    {
                        Console.WriteLine($"{friends[index]} was lost due to an error.");
                        friends[index] = "Lost";
                        allLostNames++;
                    }
                }
                else if (comand == "Change")
                {
                    int index = int.Parse(comandArg[1]);
                    string newName = comandArg[2];

                    if (friends.Count > index)
                    {
                        string currentName = friends[index];
                        Console.WriteLine($"{currentName} changed his username to {newName}.");
                        friends[index] = newName;
                    }
                }

                input = Console.ReadLine();

            }

            Console.WriteLine($"Blacklisted names: {allBlacklisted}");
            Console.WriteLine($"Lost names: {allLostNames}");
            Console.WriteLine(string.Join(' ', friends));

        }
    }
}
