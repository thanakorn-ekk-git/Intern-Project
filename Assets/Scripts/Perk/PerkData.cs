using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Perk
{
    [JsonObject]
    public class PerkData
    {
        public static string Path => System.IO.Path.Combine(GameData.GameData.Instance.GameDataPath, "Perks");

        [JsonProperty] public string Name { get; private set; } = "<Perk_Name>";
        [JsonProperty] public float Position_x { get; private set; }
        [JsonProperty] public float Position_y { get; private set; }
        [JsonProperty] public float Size { get; private set; }
        [JsonProperty] public string Description { get; private set; } = "<Perk_Description>";
        [JsonProperty] public List<Perk.PerkTag> Tags { get; private set; }
        [JsonProperty] public string ImagePath { get; private set; } = "<Image_Path_Error>";
        [JsonProperty] public string[] RequiredPerk { get; private set; } = Array.Empty<string>();
        [JsonProperty] public List<Level> Levels { get; private set; } = new List<Level>();


        private Dictionary<int, Level> cacheLevels;

        public void Cache()
        {
            
            cacheLevels = new Dictionary<int, Level>();
            if(Levels != null)
            {
                foreach(var level in Levels)
                {
                    cacheLevels.Add(level.PerkLevel, level);
                }
            }
        }

        public Level GetLevelData(int level)
        {
            Cache();

            if(cacheLevels!=null && cacheLevels.TryGetValue(level, out var levelData))
            {
                return levelData;
            }
            return null;
        }


        public class Level
        {
            [JsonProperty("Level")] public int PerkLevel { get; private set; } = 0;
            [JsonProperty] public int EnhancementCost { get; private set; } = 1;
            [JsonProperty] public List<Modifier> Modifiers { get; private set; } = new List<Modifier>();
        }
        public class Modifier
        {
            [JsonProperty] public Perk.Modifier StatType { get; private set; } 
            [JsonProperty] public float Value { get; private set; } = 0f;
        }
    }
}