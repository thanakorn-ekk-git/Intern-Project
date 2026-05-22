using Attack;
using Character;
using Enemy;
using Newtonsoft.Json;
using Player;
using System.Diagnostics;
using UnityEngine;

namespace Data
{
    public enum EnemyType{
        Mini, Normal, MiniBoss, Boss
    }

    [JsonObject]
    public class EnemyGameData
    {
        [JsonProperty] private string id = "0000";
        [JsonProperty] private EnemyType enemyType;

        [JsonProperty] public EnemyStats stats { get; private set; } = new EnemyStats();
        [JsonProperty] public EnemyRewards rewards { get; private set; } = new EnemyRewards();

        public void Load(EnemyGameData data)
        {
            id = data.id;
            enemyType = data.enemyType;
            stats = data.stats;
            rewards = data.rewards;
        }

        [JsonObject]
        public class EnemyStats : IAttackable, IDefendable
        {
            [JsonProperty] public int maxHealth { get; private set; }
            [JsonProperty] public int atkDamage { get; private set; }
            [JsonProperty] public int defense { get; private set; }
            [JsonProperty] public float moveSpeed { get; private set; }

            [JsonProperty] public float attackSpeed { get; private set; }
            [JsonProperty] public float attackRange { get; private set; }
            [JsonProperty] public float detectionRange { get; private set; }
            [JsonProperty] public float knockbackResistant { get; private set; }

            const int zeroValueForUnusedStat = 0;
            public int AtkDamage => zeroValueForUnusedStat;
            public int Strength => zeroValueForUnusedStat;
            public int Defense => zeroValueForUnusedStat;
        }

        [JsonObject]
        public class EnemyRewards
        {
            [JsonProperty] public int expDrop { get; private set; }
            [JsonProperty] public int goldDrop { get; private set; }
            // TODO : add item drop [JsonProperty] private List<Item> itemDrop = new List<Item>();
        }

    }
}