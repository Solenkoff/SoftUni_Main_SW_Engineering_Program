using System;
using System.Collections.Generic;
using System.Linq;

namespace _10_Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> namesList = Console.ReadLine()
                                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                            .ToList();

            string input = Console.ReadLine();

            while (input != "Party!")
            {
                var commands = input.Split().ToList();
                string command = commands[0];
                string critirea = commands[1];
                string arg = commands[2];

                var predicate = GetPredicate(critirea, arg);

                switch (command)
                {
                    case "Remove":
                        namesList.RemoveAll(predicate);
                        break;

                    case "Double":

                        var matches = namesList.FindAll(predicate);

                        if (matches.Count > 0)
                        {
                            int index = namesList.FindIndex(predicate);
                            namesList.InsertRange(index, matches);
                        }

                        break;

                }

                input = Console.ReadLine();
            }

            if (namesList.Count != 0)
            {
                Console.WriteLine(string.Join(", ", namesList) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }


        private static Predicate<string> GetPredicate(string critirea, string arg)

        {
            switch (critirea)
            {
                case "StartsWith":
                    return (name) => name.StartsWith(arg);
                case "EndsWith":
                    return (name) => name.EndsWith(arg);
                case "Length":
                    return (name) => name.Length == int.Parse(arg);
                default:
                    throw new ArgumentException("Invalid command type: " + critirea);

            }
        }

    }
}
