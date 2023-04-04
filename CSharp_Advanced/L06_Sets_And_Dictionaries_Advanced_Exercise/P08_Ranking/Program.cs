using System;
using System.Collections.Generic;
using System.Linq;

namespace _08_Ranking_
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, string> contests = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> candidates = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();

            while (input != "end of contests")
            {
                string[] contestsData = input.Split(':', StringSplitOptions.RemoveEmptyEntries);
                string contest = contestsData[0];
                string password = contestsData[1];

                contests.Add(contest, password);

                input = Console.ReadLine();
            }

            string inputTwo = Console.ReadLine();

            while (inputTwo != "end of submissions")
            {
                string[] submissionsData = inputTwo.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string contest = submissionsData[0];
                string password = submissionsData[1];
                string username = submissionsData[2];
                int points = int.Parse(submissionsData[3]);

                if (contests.ContainsKey(contest) && contests[contest] == password)
                {
                    if (!candidates.ContainsKey(username))
                    {
                        candidates.Add(username, new Dictionary<string, int>());

                    }
                    if (candidates[username].ContainsKey(contest))
                    {
                        if(points > candidates[username][contest])
                        {
                            candidates[username][contest] = points;
                        }                  
                    }
                    else
                    {
                        candidates[username].Add(contest, points);
                    }
                }

                inputTwo = Console.ReadLine();
            }

                KeyValuePair<string, Dictionary<string, int>> bestcandidate = candidates.OrderByDescending(x => x.Value.Values.Sum()).First();
            Console.WriteLine($"Best candidate is {bestcandidate.Key} with total {bestcandidate.Value.Values.Sum()} points.");
            Console.WriteLine("Ranking:");
        
            foreach (var student in candidates.OrderBy(x => x.Key))
            {
                Console.WriteLine(student.Key);

                foreach (var contest in student.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }

        }
    }
}
