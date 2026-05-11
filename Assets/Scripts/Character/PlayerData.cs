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
            [JsonProperty] public int level = 1;
            [JsonProperty] public int exp = 0;

            public override string ToString()
            {
                return $"Level: {level} {exp}";
            }
        }

        [JsonObject]
        public class PlayerStats
        {
            [JsonProperty] public int health = 100;
            [JsonProperty] public int mana = 50;
            [JsonProperty] public int strength = 0;
            [JsonProperty] public int dexity = 0;
            [JsonProperty] public int defence = 0;
            [JsonProperty] public int intelligence = 0;

            public override string ToString()
            {
                return $"Health = {health}\nMana = {mana}\nStrength = {strength}\nDexterity = {dexity}\nDefence = {defence}\nIntelligence = {intelligence}";
            }
        }
    }
}