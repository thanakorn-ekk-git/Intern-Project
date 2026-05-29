using Data;
using Newtonsoft.Json;

namespace Character
{
    [JsonObject]
    public class CharacterGameData
    {
        public static string Path => System.IO.Path.Combine(GameData.GameData.Instance.GameDataPath, "Characters");

        [JsonProperty] public PlayerGameData Player { get; private set; } = new PlayerGameData();
        [JsonProperty] public EnemyGameData Enemy { get; private set; } = new EnemyGameData();

        [JsonProperty] public string ID { get; private set; }
        [JsonProperty] public ItemDrop[] ItemDrops { get; private set; } = System.Array.Empty<ItemDrop>();

        public void OnLoaded()
        {
            foreach (var item in ItemDrops)
            {
                item.CacheItem();
            }
        }
        public void Load(CharacterGameData characterData)
        {
            Player.Load(characterData.Player);
            Enemy.Load(characterData.Enemy);
        }
        public string ToStringEnemy()
        {
            return $"{nameof(Character.Enemy)}:{ID} type:{Enemy.EnemyType} " +
                $"\n\nStats\nMax Health:{Enemy.Stats.MaxHealth}" +
                $"\nAttack Power:{Enemy.Stats.AtkDamage}" +
                $"\nDefense:{Enemy.Stats.Defense}" +
                $"\nMove Speed:{Enemy.Stats.MoveSpeed}" +
                $"\nAttack Speed:{Enemy.Stats.AttackSpeed}" +
                $"\nAttackRange:{Enemy.Stats.AttackRange}" +
                $"\nDetection Range:{Enemy.Stats.DetectionRange}" +
                $"\nKnockback Resistant:{Enemy.Stats.KnockbackResistant}" +
                $"\nAttackSpeed:{Enemy.Stats.AttackSpeed}" + 
                $"\n\nRewards\nExp Drop:{Enemy.Rewards.ExpDrop}" +
                $"\nGold Drop:{Enemy.Rewards.GoldDrop}";
        }
    }

    [JsonObject]
    public class ItemDrop
    {
        [JsonProperty] public string ItemID { get; private set; }
        [JsonProperty] public int Amount { get; private set; } = 1;

        [JsonIgnore] public Items.ItemGameData Item { get; private set; }

        public void CacheItem()
        {
            GameData.GameData.Instance.TryGetItem(ItemID, out var itemOut);
            Item = itemOut;
        }

    }
}   