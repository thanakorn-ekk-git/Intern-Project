using Newtonsoft.Json;
using System.Collections.Generic;

namespace Perk
{
    [JsonObject]
    public class PerkData
    {
        public static string Path => System.IO.Path.Combine(GameData.GameData.Instance.GameDataPath, "Perks");

        [JsonProperty] public string Name { get; private set; } = "<Perk_Name>";
        [JsonProperty] public string Description { get; private set; } = "<Perk_Description>";
        [JsonProperty] public List<string> Tag { get; private set; } = new List<string>();
        [JsonProperty] public string ImagePath { get; private set; } = "<Image_Path_Error>";
        [JsonProperty] public string RequiredPerk { get; private set; } = "No Required Perk";
        [JsonProperty] public List<PerkLevels> Levels { get; private set; } = new List<PerkLevels>();

        public class PerkLevels
        {
            [JsonProperty] public int Level { get; private set; } = 0;
            [JsonProperty] public int EnhancementCost { get; private set; } = 1;
            [JsonProperty] public List<PerkModifiers> Modifiers { get; private set; } = new List<PerkModifiers>();
        }
        public class PerkModifiers
        {
            [JsonProperty] public string StatType { get; private set; } = string.Empty;
            [JsonProperty] public float Value { get; private set; } = 0f;
        }
        public class Properties 
        {
            [JsonProperty] public string PropertyName { get; private set; } = string.Empty;
            [JsonProperty] public bool PropertyBool { get; private set; } = false;
        }

    }

}