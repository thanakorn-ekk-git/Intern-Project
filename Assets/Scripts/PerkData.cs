using Newtonsoft.Json;
using System.Collections.Generic;

namespace Perk
{
    [JsonObject]
    public class PerkData
    {
        public static string Path => System.IO.Path.Combine(GameData.GameData.Instance.GameDataPath, "Perks");

        [JsonProperty] public string Name { get; private set; }
        [JsonProperty] public string Description { get; private set; }
        [JsonProperty] public List<string> Tag { get; private set; }
        [JsonProperty] public string ImagePath { get; private set; }
        [JsonProperty] public string RequiredPerk { get; private set; }
        [JsonProperty] public List<PerkLevels> Levels { get; private set; }

        public class PerkLevels
        {
            [JsonProperty] public int Level { get; private set; }
            [JsonProperty] public int EnhancementCost { get; private set; }
            [JsonProperty] public List<PerkModifiers> Modifiers { get; private set; }
        }
        public class PerkModifiers
        {
            [JsonProperty] public string StatType { get; private set; }
            [JsonProperty] public float Value { get; private set; }
        }
    }

}