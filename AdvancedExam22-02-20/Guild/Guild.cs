using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        List<Player> players;

        public Guild(string name, int capacity)
        {
            this.players = new List<Player>();
            Name = name;
            Capacity = capacity;

        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count 
        { 
            get
            {
                return players.Count;
            }
        }

        public void AddPlayer(Player player)
        {
            if (players.Count < Capacity)
            {
                players.Add(player);
            }
        }
        public bool RemovePlayer(string name)
        {
            return players.Remove(players.FirstOrDefault(p => p.Name == name));
        }
        public void PromotePlayer(string name)
        {
            var player = players.FirstOrDefault(p => p.Name == name);

            if (player.Rank == "Trial")
            {
                player.Rank = "Member";
            }
        }
        public void DemotePlayer(string name)
        {
            var player = players.FirstOrDefault(p => p.Name == name);
            if (player.Rank == "Member")
            {
                player.Rank = "Trial";
            }
        }
        public Player[] KickPlayersByClass(string playerClass)
        {
            var playersArray = players.FindAll(p => p.Class == playerClass).ToArray();
            players.RemoveAll(p => p.Class == playerClass);
            return playersArray;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Players in the guild: {this.Name}");
            foreach (var item in players)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
