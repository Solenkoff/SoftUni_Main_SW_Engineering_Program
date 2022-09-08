using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04_Teamwork_Projects
{
    class Program
    {
        static void Main(string[] args)
        {

            int nTeams = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>();

            for (int i = 0; i < nTeams; i++)
            {
                string[] newTeamData = Console.ReadLine()
                                           .Split("-", StringSplitOptions.RemoveEmptyEntries);

                string creator = newTeamData[0];
                string teamName = newTeamData[1];
                Team team = new Team(teamName, creator);

                bool doesTeamExist = teams.Select(x => x.TeamName).Contains(teamName);
                bool doesCreatorExist = teams.Select(x => x.Creator).Contains(creator);

                if (!doesTeamExist)
                {
                    if (!doesCreatorExist)
                    {
                        teams.Add(team);
                        Console.WriteLine($"Team {teamName} has been created by {creator}!");
                    }
                    else
                    {
                        Console.WriteLine($"{creator} cannot create another team!");
                    }
                }
                else if (doesTeamExist)
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
            }

            string teamMmember = Console.ReadLine();

            while (teamMmember != "end of assignment")
            {
                string[] newMember = teamMmember.Split(new char[] { '-', '>' }.ToArray());
                string newUser = newMember[0];
                string teamName = newMember[2];

                bool doesTeamExist = teams.Select(x => x.TeamName).Contains(teamName);
                bool doesCreatorExist = teams.Select(x => x.Creator).Contains(newUser);
                bool doesMemberExist = teams.Select(x => x.Members)
                                            .Any(x => x.Contains(newUser));

                if (!doesTeamExist)
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                }
                else if (doesCreatorExist || doesMemberExist)
                {
                    Console.WriteLine($"Member {newUser} cannot join team {teamName}!");
                }
                else
                {
                    int index = teams.FindIndex(x => x.TeamName == teamName);
                    teams[index].Members.Add(newUser);
                }

                teamMmember = Console.ReadLine();
            }


            Team[] teamsToDisband = teams.OrderBy(x => x.TeamName)
                                         .Where(x => x.Members.Count == 0)
                                         .ToArray();
            Team[] remainingTeams = teams.OrderByDescending(x => x.Members.Count)
                                         .ThenBy(x => x.TeamName)
                                         .Where(x => x.Members.Count > 0)
                                         .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (Team team in remainingTeams)
            {
                sb.AppendLine($"{team.TeamName}");
                sb.AppendLine($"- {team.Creator}");

                foreach (var member in team.Members.OrderBy(x => x))
                {
                    sb.AppendLine($"-- {member}");
                }
            }

            sb.AppendLine("Teams to disband:");
            foreach (Team item in teamsToDisband)
            {
                sb.AppendLine(item.TeamName);
            }

            Console.WriteLine(sb.ToString());

        }
    }

    class Team
    {
        public Team(string teamName, string creator)
        {
            TeamName = teamName;
            Creator = creator;
            Members = new List<string>();
        }

        public string TeamName { get; set; }
        public string Creator { get; set; }
        public List<string> Members { get; set; }
    }

}
