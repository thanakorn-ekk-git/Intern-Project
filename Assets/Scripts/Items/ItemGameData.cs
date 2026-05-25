using Newtonsoft.Json;

namespace Items {
    [JsonObject]
    public class ItemGameData
    {
        public static string Path => System.IO.Path.Combine(GameData.GameData.Instance.GameDataPath, "Items");

        [JsonProperty] public string ID { get; private set; }
        [JsonProperty] public int price { get; private set; }

        [JsonConstructor]
        public ItemGameData() { }

        public override string ToString()
        {
            return nameof(ItemGameData) + ":" + ID;
        }
    }
}