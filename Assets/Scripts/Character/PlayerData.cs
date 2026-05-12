using UnityEngine;
using Newtonsoft.Json;

namespace Data
{
    [JsonObject]
    public class PlayerData
    {
        [JsonProperty] private string name = "Hero";
        [JsonProperty] private PlayerLevel level = new PlayerLevel();
        [JsonProperty] private PlayerStats stats = new PlayerStats();

        public void Save()
        {
            // TODO : pull player's data to be serialized (player name, level, health, status, inventory, etc.)
        }

        public void Load()
        {
            // TODO : apply loaded data to player data (player name, level, health, status, inventory, etc.)
        }

        public override string ToString()
        {
            return $"{GetType()} {name} {level} {stats}";
        }

        [JsonObject]
        public class PlayerLevel 
        { 
            [JsonProperty] private int level = 1;
            [JsonProperty] private int exp = 0;

            public override string ToString()
            {
                return $"Level: {level} {exp}";
            }
        }

        [JsonObject]
        public class PlayerStats
        {
            [JsonProperty] private int health = 100;
            [JsonProperty] private int mana = 50;
            [JsonProperty] private int strength = 0;
            [JsonProperty] private int dexterity = 0;
            [JsonProperty] private int defence = 0;
            [JsonProperty] private int intelligence = 0;

            public override string ToString()
            {
                return $"Health = {health}\nMana = {mana}\nStrength = {strength}\nDexterity = {dexterity}\nDefence = {defence}\nIntelligence = {intelligence}";
            }
        }
    }
}