using Attack;
using Newtonsoft.Json;
using Player;
using UnityEngine;

namespace Data
{
    [JsonObject]
    public class PlayerGameData
    {
        [JsonProperty] private string name = "Hero";
        [JsonProperty] private PlayerLevel level = new PlayerLevel();
        [JsonProperty] private PlayerStats stats = new PlayerStats();

        public void Save()
        {
            // TODO : pull player's data to be serialized (player name, level, health, status, inventory, etc.)
        }

        public void Load(PlayerGameData data)
        {
            name = data.name;
            level = data.level;
            stats = data.stats;

            var tmpPlayer = GameObject.FindFirstObjectByType<PlayerController>();
            if (tmpPlayer.TryGetComponent<Attacker>( out var attacker) && tmpPlayer.TryGetComponent<EntityWithHealth>(out var defender))
            { 
                attacker.SetData(stats.AtkDamage, stats.Strength);
                defender.SetData(stats.Defense);
            }
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
                return $"Level: {level}\nExp: {exp}";
            }
        }

        [JsonObject]
        public class PlayerStats
        {
            public int MaxHealth => maxHealth;
            [JsonProperty] private int maxHealth = 100;
            public int Health => health;
            [JsonProperty] private int health = 100;
            public int Mana => mana;
            [JsonProperty] private int mana = 50;
            public int AtkDamage => atkDamage;
            [JsonProperty] private int atkDamage = 0;
            public int Strength => strength;
            [JsonProperty] private int strength = 0;
            public int Dexterity => dexterity;
            [JsonProperty] private int dexterity = 0;
            public int Defense => defense;
            [JsonProperty] private int defense = 0;
            public int Intelligence => intelligence;
            [JsonProperty] private int intelligence = 0;
            [JsonProperty] private float critRate = 0;
            [JsonProperty] private float critStrength = 0;


            public override string ToString()
            {
                return $"Max Health = {maxHealth}\nMana = {mana}\nStrength = {strength}\nDexterity = {dexterity}\n" +
                    $"Defense = {defense}\nIntelligence = {intelligence}\nCrit Rate = {critRate}\nCrit Strength = {critStrength}";
            }
        }
    }
}