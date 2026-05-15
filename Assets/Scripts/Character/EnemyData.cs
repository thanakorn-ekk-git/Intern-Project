using Newtonsoft.Json;
using System.Collections.Generic;

namespace Data
{
    public enum EnemyType{
        Mini, Normal, MiniBoss, Boss
    }

    [JsonObject]
    public class EnemyData
    {
        [JsonProperty] private string id = "0000";
        [JsonProperty] private EnemyType enemyType;
        [JsonProperty] private float physicalSize = 1f;
        [JsonProperty] private int hordeSize = 1;

        [JsonProperty] private EnemyStats stats = new EnemyStats();
        [JsonProperty] private List<EnemyReward> rewards = new List<EnemyReward>();

        [JsonObject]
        public class EnemyStats
        {
            [JsonProperty] private int maxHealth;
            [JsonProperty] private int attackPower;
            [JsonProperty] private int defense;
            [JsonProperty] private float moveSpeed;

            [JsonProperty] private float attackSpeed;
            [JsonProperty] private float attackRange;
            [JsonProperty] private float detectionRange;
            [JsonProperty] private float knockbackResistant;

        }

        [JsonObject]
        public class EnemyReward
        {
            [JsonProperty] private int expDrop;
            [JsonProperty] private int goldDrop;
            // TODO : add item drop [JsonProperty] private List<Item> itemDrop = new List<Item>();
        }
    }
}