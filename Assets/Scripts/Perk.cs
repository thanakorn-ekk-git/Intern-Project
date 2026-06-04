using System;
using System.Linq;

namespace Perk
{
    public class Perk
    {
        public PerkData Data => data;
        private  PerkData data;

        public bool isUnlocked = false;

        public int CurrentLevel { get; private set; } = 1;
        public PerkExcutor Excutor { get; private set; }

        public Perk(PerkData data)
        {
            this.data = data;
        }

        public void SetExcutor(PerkExcutor excutor)
        {
            Excutor = excutor;
            Excutor.Initailize(this);
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