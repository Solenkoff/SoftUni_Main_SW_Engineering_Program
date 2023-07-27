using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootbalTeamGenerator
{
    public class Team
    {
        private string name;
        private Dictionary<string, Player> playersByName;

        public Team(string name)
        {
            this.Name = name;
            this.playersByName = new Dictionary<string, Player>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                Validator.ThrowIfStringIsNullOrWhiteSpace(value, GlobalConstants.InvalidNameErrorMessage);

                this.name = value;
            }
        }


        public int AverageRating
        {
            get
            {
                if(this.playersByName.Count == 0)
                {
                    return 0;
                }

                return (int)Math.Round(this.playersByName.Values.Average(x => x.AverageSkillPoints));
            }
        }



        public void AddPlayer(Player player)
        {
            this.playersByName.Add(player.Name, player);
        }


        public void RemovePlayer(string playerName)
        {
            if(!this.playersByName.ContainsKey(playerName))
            {
                throw new InvalidOperationException($"Player {playerName} is not in {this.Name} team.");
            }

            this.playersByName.Remove(playerName);
        }

    }
}
