using System;
using System.Linq;

namespace Perk
{
    public class Perk
    {
        public PerkData Data => data;
        private  PerkData data;

        public bool isUnlocked { get; private set; } = false;

        public int CurrentLevel { get; private set; } = 1;
        public PerkExecutor Excutor { get; private set; }

        public Perk(PerkData data)
        {
            this.data = data;
        }

        public void SetExcutor(PerkExecutor excutor)
        {
            Excutor = excutor;
            Excutor.Initialize(this);
        }
        
        public void Unlock()
        {
            isUnlocked = true;
        }
        public void LevelUp()
        {
            CurrentLevel++;
        }

        public string GetLevel()
        {
            if (data == null || data.Levels == null)
            {
                return "0";
            }

            var levelData = data.Levels;

            if (levelData != null)
            {
                var curLevel = levelData.Find(level => level.Level == CurrentLevel);
                string str = curLevel != null ? $"{curLevel.Level}/{levelData.Count}" : "0";
                return str;
            }
            return "0";
        }
        public float GetModifierValue(string statType)
        {
            if (data == null || data.Levels == null)
            {
                return 0f;
            }

            var levelData = data.Levels.Find(level => level.Level == CurrentLevel);
            if(levelData != null && levelData.Modifiers != null)
            {
                var modifier = levelData.Modifiers.Find(m => m.StatType == statType);
                if(modifier != null)
                {
                    return modifier.Value;
                }
            }
            return 0f;
        }
        public bool GetProperty(string propertyName)
        {
            if (data == null || data.Levels == null)
            {
                return false;
            }

            var levelData = data.Levels.Find(level => level.Level == CurrentLevel);
            if (levelData != null && levelData.Properties != null)
            {
                var property = levelData.Properties.Find(p => p.Property == propertyName);
                if (property != null)
                {
                    return property.Value;
                }
            }
            return false;
        }

        public string GetTag()
        {
            string[] perkTags = Array.Empty<string>();
            if (data == null || data.Tag == null || data.Tag.Count == 0)
            {
                return string.Empty;
            }
            foreach ( var tag in data.Tag ) {
                perkTags = perkTags.Append(tag).ToArray();
            }
            return perkTags.Length > 0 ? perkTags[0] : string.Empty;
        }
    }
}