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
        [JsonProperty] public EnemyType EnemyType { get; private set; }

        [JsonProperty] public EnemyStats Stats { get; private set; } = new EnemyStats();
        [JsonProperty] public EnemyRewards Rewards { get; private set; } = new EnemyRewards();

        public void Load(EnemyGameData data)
        {
            id = data.id;
            EnemyType = data.EnemyType;
            Stats = data.Stats;
            Rewards = data.Rewards;
        }

        [JsonObject]
        public class EnemyStats : IAttackable, IDefendable
        {
            [JsonProperty] public int MaxHealth { get; private set; }
            [JsonProperty] public int AtkDamage { get; private set; }
            [JsonProperty] public int Defense { get; private set; }
            [JsonProperty] public float MoveSpeed { get; private set; }

            [JsonProperty] public float AttackSpeed { get; private set; }
            [JsonProperty] public float AttackRange { get; private set; }
            [JsonProperty] public float DetectionRange { get; private set; }
            [JsonProperty] public float KnockbackResistant { get; private set; }

            const int zeroValueForUnusedStat = 0;
            public int Strength => zeroValueForUnusedStat;
        }

        [JsonObject]
        public class EnemyRewards
        {
            [JsonProperty] public int ExpDrop { get; private set; }
            [JsonProperty] public int GoldDrop { get; private set; }
            // TODO : add item drop [JsonProperty] private List<Item> itemDrop = new List<Item>();
        }

    }
}