using GameManagement;
using System;
using UnityEngine;

namespace Perk
{
    public class Perk
    {
        public PerkData Data => data;
        private PerkData data;

        public bool isUnlocked => CurrentLevel >= 0;
        public int CurrentLevel { get; private set; } = 1;

        private int cooldown = 0;

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
            DamageTakenPercentage,
            Speed,
            Projectile,
            RotateAround,
            LinearAttack,
            SpawnDuration,
            AOE,
            SpawnInterval
        }
        public Modifier Type { get; private set; }

        public enum Tag
        {
            none, movement, attack, defense, buff, utility, blood, ice, fire, stone
        }

        public Tag[] _Tag => data.Tags;

        public Perk(PerkData data)
        {
            this.data = data;
        }

        public bool CanCast(PerkManager manager)
        {
            return cooldown < Time.frameCount;
        }

        public void Cast(PerkManager manager)
        {
            var level = Data.GetLevelData(CurrentLevel);
            Debug.Log(level);
            foreach (var mod in level.Modifiers)
            {
                switch (mod.StatType)
                {
                    case Modifier.Projectile:
                        foreach (var tag in _Tag)
                        {
                            if (GameManager.Instance.GameConfigs.Projectiles.TryGetProjectile(tag, out var prefab))
                            {
                                var projectileSpawner = GameManager.Instance.GameConfigs.ProjectileSpawner;
                                GameObject.Instantiate(projectileSpawner, manager.Owner.transform.position, manager.Owner.transform.rotation, manager.Owner.transform).Setup(level.ModifiersByID, prefab.gameObject);
                                cooldown = Time.frameCount + Mathf.RoundToInt(level.ModifiersByID.GetValueOrDefault(Modifier.Cooldown, 1f) * Application.targetFrameRate);
                                break;
                            }
                        }
                        break;
                    case Modifier.AOE:
                        foreach (var tag in _Tag)
                        {
                            if (GameManager.Instance.GameConfigs.AOES.TryGetAOE(tag, out var prefab))
                            {
                                var aoeSpawner = GameManager.Instance.GameConfigs.AOESpawner;
                                GameObject.Instantiate(aoeSpawner, manager.Owner.transform.position, manager.Owner.transform.rotation, manager.Owner.transform).Setup(level.ModifiersByID, prefab.gameObject);
                                cooldown = Time.frameCount + Mathf.RoundToInt(level.ModifiersByID.GetValueOrDefault(Modifier.Cooldown, 1f) * Application.targetFrameRate);
                            }
                        }
                        break;
                }
            }
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

            if (level.ModifiersByID.TryGetValue(statType, out var outModifier))
            {
                return outModifier.Value;
            }
            return 0f;
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