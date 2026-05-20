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

        [JsonProperty] private EnemyStats stats = new EnemyStats();
        [JsonProperty] private EnemyRewards rewards = new EnemyRewards();

        public void Load(EnemyGameData data)
        {
            id = data.id;
            enemyType = data.enemyType;
            stats = data.stats;
            rewards = data.rewards;

            var tmpEnemy = GameObject.FindFirstObjectByType<EnemyBehavior>();
            if (tmpEnemy.TryGetComponent<Attacker>(out var attacker) && tmpEnemy.TryGetComponent<EntityWithHealth>(out var defender))
            {
                attacker.SetData(stats.AtkDamage, stats.Strength);
                defender.SetData(stats.Defense);
            }

        }

        [JsonObject]
        public class EnemyStats : IAttackable, IDefendable
        {
            [JsonProperty] private int maxHealth;
            [JsonProperty] private int atkDamage;
            [JsonProperty] private int defense;
            [JsonProperty] private float moveSpeed;

            [JsonProperty] private float attackSpeed;
            [JsonProperty] private float attackRange;
            [JsonProperty] private float detectionRange;
            [JsonProperty] private float knockbackResistant;

            public int AtkDamage => atkDamage;
            public int Strength => 0;

            public int Defense => defense;
        }

        [JsonObject]
        public class EnemyRewards
        {
            [JsonProperty] private int expDrop;
            [JsonProperty] private int goldDrop;
            // TODO : add item drop [JsonProperty] private List<Item> itemDrop = new List<Item>();
        }

    }
}