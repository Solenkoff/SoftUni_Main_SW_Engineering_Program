using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_The_V_Logger_
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, Dictionary<string, SortedSet<string>>> vloggers = new Dictionary<string, Dictionary<string, SortedSet<string>>>();

            string input = Console.ReadLine();

            while (input != "Statistics")
            {
                string[] commands = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string vloggerName = commands[0];
                string command = commands[1];

                if (command == "joined" && !vloggers.ContainsKey(vloggerName))
                {
                    vloggers.Add(vloggerName, new Dictionary<string, SortedSet<string>>());
                    vloggers[vloggerName].Add("followers", new SortedSet<string>());
                    vloggers[vloggerName].Add("following", new SortedSet<string>());
                }
                else if (command == "followed")
                {
                    string vloggerToFollow = commands[2];
                    if (vloggers.ContainsKey(vloggerName) && vloggers.ContainsKey(vloggerToFollow)
                        && vloggerName != vloggerToFollow && !vloggers[vloggerName]["following"].Contains(vloggerToFollow))
                    {
                        vloggers[vloggerToFollow]["followers"].Add(vloggerName);
                        vloggers[vloggerName]["following"].Add(vloggerToFollow);
                    }
                }

                input = Console.ReadLine();
            }

            var sortedVloggers = vloggers.OrderByDescending(kvp => kvp.Value["followers"].Count)
                                     .ThenBy(kvp => kvp.Value["following"].Count)
                                     .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            int counter = 0;

            foreach (var vlogger in sortedVloggers)
            {

                Console.WriteLine($"{++counter}. {vlogger.Key} : " +
                    $"{vlogger.Value["followers"].Count} followers, {vlogger.Value["following"].Count} following");

                if (counter == 1)
                {
                    foreach (var follower in vlogger.Value["followers"])
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
              
            }
        }
    }
}
