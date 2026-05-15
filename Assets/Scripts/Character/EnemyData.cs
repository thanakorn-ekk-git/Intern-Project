using Newtonsoft.Json;
using System.Xml.Serialization;

namespace Data
{
    public enum EnemyType{
        Mini, Normal, MiniBoss, Boss
    }

    [JsonObject]
    public class EnemyData
    {
        [JsonProperty] private string name = "Enemy";
        [JsonProperty] private string id = "0000";
        [JsonProperty] private EnemyType enemyType;

        [JsonProperty] private EnemyStats stats = new EnemyStats();
        [JsonProperty] private EnemyRewards rewards = new EnemyRewards();

        public void Load()
        {

        }

        [JsonObject]
        public class EnemyStats
        {
            [JsonProperty] private int maxHealth;
            [JsonProperty] private int atkDamage;
            [JsonProperty] private int defense;
            [JsonProperty] private float moveSpeed;

            [JsonProperty] private float attackSpeed;
            [JsonProperty] private float attackRange;
            [JsonProperty] private float detectionRange;
            [JsonProperty] private float knockbackResistant;
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