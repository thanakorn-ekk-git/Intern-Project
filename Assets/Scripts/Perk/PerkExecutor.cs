using Player;
using System.Collections.Generic;
using UnityEngine;

namespace Perk
{
    public class PerkExecutor
    {
        [SerializeField] private PlayerController owner;
        protected Perk parentPerk;

        public void Initialize(Perk perk, PlayerController owner)
        {
            this.parentPerk = perk;
            this.owner = owner;
        }

        public string GetStatValue()
        {
            if(parentPerk == null||parentPerk.Data== null)
            {
                return string.Empty;
            }

            int maxLevel = 0;
            int currentLevel = parentPerk.GetLevel(out  maxLevel);
            var currentLevelData = parentPerk.Data.GetLevelData(parentPerk.CurrentLevel);

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendLine($"{parentPerk.Data.Name} Modifiers (Level: {currentLevelData.Level}/{maxLevel}");

            if (currentLevelData != null && currentLevelData.Modifiers != null)
            {
                foreach (var modifier in currentLevelData.Modifiers)
                {
                    sb.AppendLine($"\t{modifier.StatType}: {modifier.Value}");
                }
            }
            return sb.ToString();
        }

        public void OnUpdate()
        {

        }

        public void OnUnlocked()
        {
            Debug.Log(parentPerk.Data.Name + " unlocked");
        }
        public void OnEquipped()
        {
            Debug.Log(parentPerk.Data.Name + " equipped");
        }
        public void OnUnequipped()
        {
            Debug.Log(parentPerk.Data.Name + " unequipped");
        }
        public void OnActive()
        {
            Debug.Log(parentPerk.Data.Name + " is active");
        }
        public void OnEnhance()
        {
            Debug.Log(parentPerk.Data.Name + " enhanced");
        }
    }
}