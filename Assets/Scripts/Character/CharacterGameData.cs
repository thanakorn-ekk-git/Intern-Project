using Newtonsoft.Json;

namespace Character
{
    [JsonObject]
    public class CharacterGameData
    {
        public static string Path => System.IO.Path.Combine(GameData.GameData.Instance.GameDataPath, "Characters");

        [JsonProperty] public string ID { get; private set; }
        [JsonProperty] public ItemDrop[] ItemDrops { get; private set; } = System.Array.Empty<ItemDrop>();

        public void OnLoaded()
        {
            foreach(var item in ItemDrops)
            {
                item.CacheItem();
            }
        }
    }
    [JsonObject]
    public class ItemDrop
    {
        [JsonProperty] public string ID;
        [JsonProperty] public int Amount { get; private set; } = 1;

        [JsonIgnore] public Items.ItemGameData Item { get; private set; }

        public void CacheItem()
        {
            GameData.GameData.Instance.TryGetItem(ID, out var itemOut);
            Item = itemOut;
        }
    }
}