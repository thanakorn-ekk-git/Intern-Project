using Attack;
using Newtonsoft.Json;
using Player;
using UnityEngine;

namespace Data
{
    [JsonObject]
    public class PlayerGameData
    {
        [JsonProperty] private PlayerLevel level = new PlayerLevel();
        [JsonProperty] private PlayerStats stats = new PlayerStats();

        public void Load(PlayerGameData data)
        {
            level = data.level;
            stats = data.stats;

            var tmpPlayer = PlayerController.GetPlayer();
            if (tmpPlayer.TryGetComponent<Attacker>(out var attacker) && tmpPlayer.TryGetComponent<EntityWithHealth>(out var defender))
            {
                attacker.SetData(stats.atkDamage, stats.strength);
                defender.SetData(stats.defense, stats.maxHealth);
            }

        }

        public override string ToString()
        {
            return $"{GetType()} {level} {stats}";
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
            [JsonProperty] public int maxHealth { get; private set; } = 100;
            [JsonProperty] public int health { get; private set; } = 100;
            [JsonProperty] public int mana { get; private set; } = 50;
            [JsonProperty] public int atkDamage { get; private set; } = 0;
            [JsonProperty] public int strength { get; private set; } = 0;
            [JsonProperty] public int dexterity { get; private set; } = 0;
            [JsonProperty] public int defense { get; private set; } = 0;
            [JsonProperty] public int intelligence { get; private set; } = 0;
            [JsonProperty] public float critRate { get; private set; } = 0;
            [JsonProperty] public float critStrength { get; private set; } = 0;


            public override string ToString()
            {
                return $"Max Health = {maxHealth}\nMana = {mana}\nStrength = {strength}\nDexterity = {dexterity}\n" +
                    $"Defense = {defense}\nIntelligence = {intelligence}\nCrit Rate = {critRate}\nCrit Strength = {critStrength}";
            }
        }
    }
}