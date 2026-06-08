using Player;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Perk
{
    public class Perk
    {
        public PerkData Data => data;
        private  PerkData data;

        public bool isUnlocked => CurrentLevel >= 0;
        public int CurrentLevel { get; private set; } = 1;
        public PerkExecutor Executor { get; private set; }

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
        public StatType Type { get; private set; }

        public enum PerkTag 
        { 
            none, movement, attack, defense, buff, utility, blood, ice, fire, stone
        }

        public PerkTag Tag { get; private set; }

        public Perk(PerkData data)
        {
            this.data = data;
            this.data.Cache();
        }

        public void SetExcutor(PerkExecutor executor, PlayerController owner)
        {
            Executor = executor;
            Executor.Initialize(this, owner);
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
            if (data == null || data.Tags == null || data.Tags.Count == 0)
            {
                return string.Empty;
            }
            return string.Join(", ", data.Tags);
        }
    }
}