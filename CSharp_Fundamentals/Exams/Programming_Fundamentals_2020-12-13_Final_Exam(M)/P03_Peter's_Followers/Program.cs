using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_Peter_s_Followers
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, Dictionary<string, int>> followers = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();

            while (input != "Log out")
            {
                string[] commands = input.Split(": ", StringSplitOptions.RemoveEmptyEntries);

                if (commands[0] == "New follower")
                {

                    string username = commands[1];
                    if (!followers.ContainsKey(username))
                    {
                        followers.Add(username, new Dictionary<string, int>()
                        {
                            { "likes", 0 }, { "comments", 0 }
                        });
                    }

                }
                else if (commands[0] == "Like")
                {
                    string username = commands[1];
                    int countLikes = int.Parse(commands[2]);

                    if (followers.ContainsKey(username))
                    {
                        followers[username]["likes"] += countLikes;
                    }
                    else
                    {
                        followers.Add(username, new Dictionary<string, int>()
                        {
                            { "likes", countLikes }, { "comments", 0 }
                        });
                    }
                }
                else if (commands[0] == "Comment")
                {
                    string username = commands[1];

                    if (followers.ContainsKey(username))
                    {
                        followers[username]["comments"]++;

                    }
                    else
                    {
                        followers.Add(username, new Dictionary<string, int>()
                            { { "likes", 0 }, { "comments", 1 } });
                    }
                }
                else if (commands[0] == "Blocked")
                {
                    string username = commands[1];

                    if (followers.ContainsKey(username))
                    {
                        followers.Remove(username);
                    }
                    else
                    {
                        Console.WriteLine($"{username} doesn’t exist.");
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{followers.Count} followers");

            foreach (var item in followers.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value.Values.Sum()}");
            }

        }
    }
}
