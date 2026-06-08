using Player;
using System;
using System.Linq;

namespace Perk
{
    public class Perk
    {
        public PerkData Data => data;
        private  PerkData data;

        public bool isUnlocked => CurrentLevel >= 0;
        public int CurrentLevel { get; private set; } = 1;
        public PerkExecutor Excutor { get; private set; }

        public enum StatType 
        { 
            Cooldown,
            Duration,
            ArmorPoints,
            MaxLayer,
            ExplodeDamage,
            ExplodeAfterDestroyed,
            StatBuffPercentage,
            BloodCost,
            CostThreshold,
            Damage,
            Radius,
            TrailDamage,
            FreezeDuration,
            SlowDuration,
            SlowPercentage,
            Range,
            Amount,
            Layer,
            DamageTakenDuration,
            DamageTakenPercentage
        }
        public StatType type { get; private set; }

        public Perk(PerkData data)
        {
            this.data = data;
            this.data.Cache();
        }

        public void SetExcutor(PerkExecutor excutor, PlayerController owner)
        {
            Excutor = excutor;
            Excutor.Initialize(this, owner);
        }
        
        public void Unlock()
        {
            CurrentLevel = 1;
        }
        public void LevelUp()
        {
            CurrentLevel++;
        }

        public int GetLevel(out int maxLevel)
        {
            if (data != null && data.Levels != null)
            {
                maxLevel = data.Levels.Count;
                var curLevel = data.GetLevelData(CurrentLevel);
                if (curLevel != null)
                {
                    return curLevel.Level;
                }
            }
            maxLevel = 0;
            return 0;
        }
        public float GetModifierValue(PerkData.PerkLevel level, StatType statType)
        {
            if (level == null || level.Modifiers == null)
            {
                return 0f;
            }

            var modifier = level.Modifiers.Find(m => m.StatType == statType);

            if(modifier != null)
            {
                return modifier.Value;
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