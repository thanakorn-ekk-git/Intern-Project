using UnityEngine;

namespace Perk
{
    public class Perk
    {
        public PerkData Data => data;
        private  PerkData data;

        public bool isUnlocked => CurrentLevel >= 0;
        public int CurrentLevel { get; private set; } = 1;

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

        public enum Tag 
        { 
            none, movement, attack, defense, buff, utility, blood, ice, fire, stone
        }

        public Tag _Tag { get; private set; }

        public Perk(PerkData data)
        {
            this.data = data;
        }
        
        public void LevelUp()
        {
            CurrentLevel++;
        }

        public (int current, int max) GetLevel()
        {
            var curLevel = data.GetLevelData(CurrentLevel);
            if (curLevel != null)
            {
                return (curLevel.PerkLevel, data.Levels.Length);
            }
            return (0, data.Levels.Length);
        }
        public float GetModifierValue(PerkData.Level level, Modifier statType)
        {
            if (level == null)
            {
                return 0f;
            }

            if(level.ModifiersByID.TryGetValue(statType,out var outModifier))
            {
                return outModifier.Value;
            }
            return 0f;
        }
        public Tag GetTag()
        {
            if (data.Tags.Count == 0)
            {
                return _Tag;
            }
            return Tag.none;
        }
        public void OnUpdate()
        {

        }

        public void OnUnlocked()
        {
            Debug.Log(data.ID + " unlocked");
        }
        public void OnEquipped()
        {
            Debug.Log(data.ID + " equipped");
        }
        public void OnUnequipped()
        {
            Debug.Log(data.ID + " unequipped");
        }
        public void OnActive()
        {
            Debug.Log(data.ID + " is active");
        }
        public void OnEnhance()
        {
            Debug.Log(data.ID + " enhanced");
        }
    }
}