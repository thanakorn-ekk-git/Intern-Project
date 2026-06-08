using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using UnityEngine;
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
        [JsonProperty] public List<PerkLevel> Levels { get; private set; } = new List<PerkLevel>();


        private Dictionary<int, PerkLevel> cacheLevel;
        private bool isCached = false;

        public void Cache()
        {
            if (isCached) return;
            
            cacheLevel = new Dictionary<int, PerkLevel>();
            if(Levels != null)
            {
                foreach(var level in Levels)
                {
                    cacheLevel.Add(level.Level, level);
                }
            }
            isCached = true;
        }

        public PerkLevel GetLevelData(int level)
        {
            Cache();

            if(cacheLevel!=null && cacheLevel.TryGetValue(level, out var levelData))
            {
                return levelData;
            }
            return null;
        }


        public class PerkLevel
        {
            [JsonProperty] public int Level { get; private set; } = 0;
            [JsonProperty] public int EnhancementCost { get; private set; } = 1;
            [JsonProperty] public List<PerkModifier> Modifiers { get; private set; } = new List<PerkModifier>();
        }
        public class PerkModifier
        {
            [JsonProperty] public Perk.StatType StatType { get; private set; } 
            [JsonProperty] public float Value { get; private set; } = 0f;
        }
    }
}