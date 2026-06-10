using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Perk
{
    [JsonObject]
    public class PerkData
    {
        public static string Path => System.IO.Path.Combine(GameData.GameData.Instance.GameDataPath, "Perks");

        public string ID { get; private set; }
        [JsonProperty] public string Name { get; private set; } = "<Perk_Name>";
        [JsonProperty] public float Position_x { get; private set; }
        [JsonProperty] public float Position_y { get; private set; }
        [JsonProperty] public float Size { get; private set; }
        [JsonProperty] public string Description { get; private set; } = "<Perk_Description>";
        [JsonProperty] public List<Perk.Tag> Tags { get; private set; }
        [JsonProperty] public string ImagePath { get; private set; } = "<Image_Path_Error>";
        [JsonProperty] public string[] RequiredPerks { get; private set; } = Array.Empty<string>();
        [JsonProperty] public Level[] Levels { get; private set; } = Array.Empty<Level>();


        private Dictionary<int, Level> cacheLevels;

        public void Setup(string id)
        {
            ID = id;

            cacheLevels = new Dictionary<int, Level>();
            if (Levels != null)
            {
                foreach (var level in Levels)
                {
                    cacheLevels.Add(level.PerkLevel, level);
                }
            }
        }

        public Level GetLevelData(int level)
        {
            if(cacheLevels.TryGetValue(level, out var levelData))
            {
                return levelData;
            }
            return null;
        }
        public string GetDebugStatString()
        {
            int maxLevel = Levels.Length;

            var currentLevel = Levels[0];

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendLine($"{ID} Modifiers (Level: {maxLevel}");

            foreach (var modifier in currentLevel.Modifiers)
            {
                sb.AppendLine($"\t{modifier.StatType}: {modifier.Value}");
            }
            return sb.ToString();
        }

        public class Level
        {
            [JsonProperty("Level")] public int PerkLevel { get; private set; } = 0;
            [JsonProperty] public int EnhancementCost { get; private set; } = 1;
            [JsonProperty] public Modifier[] Modifiers { get; private set; } = Array.Empty<Modifier>();
            Dictionary<Perk.Modifier, Modifier> modifiersByID;
            public IReadOnlyDictionary<Perk.Modifier, Modifier> ModifiersByID => modifiersByID;
            public void Setup()
            {
                if(modifiersByID == null)
                {
                    modifiersByID = new();
                    foreach (var mod in Modifiers)
                    {
                        modifiersByID.TryAdd(mod.StatType, mod);
                    }
                }
            }
        }
        public class Modifier
        {
            [JsonProperty] public Perk.Modifier StatType { get; private set; } 
            [JsonProperty] public float Value { get; private set; } = 0f;
        }
    }
}