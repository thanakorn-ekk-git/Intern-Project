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

        public enum Modifier 
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
        public Modifier Type { get; private set; }

        public enum PerkTag 
        { 
            none, movement, attack, defense, buff, utility, blood, ice, fire, stone
        }

        public PerkTag Tag { get; private set; }

        public Perk(PerkData data)
        {
            this.data = data;
        }

        public void SetExecutor(PerkExecutor executor, PlayerController owner)
        {
            Executor = executor;
            Executor.Initialize(this, owner);
        }
        
        public void LevelUp()
        {
            CurrentLevel++;
        }

        public (int current, int max) GetLevel()
        {
            if (data != null && data.Levels != null)
            {
                var curLevel = data.GetLevelData(CurrentLevel);
                if (curLevel != null)
                {
                    return (curLevel.PerkLevel, data.Levels.Count);
                }
            }
            return (0, 0);
        }
        public float GetModifierValue(PerkData.Level level, Modifier statType)
        {
            if (level == null || level.Modifiers == null)
            {
                return 0f;
            }

            var modifier = level.Modifiers.ToDictionary(m => m.StatType);

            if(modifier.TryGetValue(statType,out var outModifier))
            {
                return outModifier.Value;
            }
            return 0f;
        }
        public PerkTag GetTag()
        {
            if (data == null || data.Tags == null || data.Tags.Count == 0)
            {
                return Tag;
            }
            return PerkTag.none;
        }
    }
}