﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {

        private List<Player> roster;

        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.roster = new List<Player>();
        }


        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => this.roster.Count;


        public void AddPlayer(Player player)
        {
            Player currP = this.roster.FirstOrDefault(x => x.Name == player.Name);
            if (this.roster.Count < this.Capacity && currP == null)
            {
                this.roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
  
            Player player = this.roster.FirstOrDefault(x => x.Name == name);

            if (player == null)
            {
                return false;
            }

            this.roster.Remove(player);

            return true;
        }


        public void PromotePlayer(string name)
        {
            Player player = this.roster.FirstOrDefault(x => x.Name == name);
            if (player != null)
            {
                this.roster.FirstOrDefault(x => x.Name == name).Rank = "Member";
            }
        }


        public void DemotePlayer(string name)
        {
            Player player = this.roster.FirstOrDefault(x => x.Name == name);
            if (player != null)
            {
                this.roster.FirstOrDefault(x => x.Name == name).Rank = "Trial";
            }
 
        }

        public Player[] KickPlayersByClass(string @class)
        {
            List<Player> selectedPlayers = new List<Player>();

            foreach (var player in this.roster)
            {
                if(player.Class == @class)
                {
                    selectedPlayers.Add(player);
                }                       
            }

            Player[] players = selectedPlayers.ToArray();
            this.roster = this.roster.Where(x => x.Class != @class).ToList();

            return players;
        }


        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Players in the guild: {this.Name}");

            foreach (var player in this.roster)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().Trim();
        }


        //public Employee GetEmployee(string name)
        //{
        //    Employee employee = this.data.FirstOrDefault(x => x.Name == name);

        //    return employee;
        //}

    }
}
