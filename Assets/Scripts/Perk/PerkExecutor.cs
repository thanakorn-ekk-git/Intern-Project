using Player;
using System.Collections.Generic;
using UnityEngine;

namespace Perk
{
    public class PerkExecutor
    {
        [SerializeField] private PlayerController owner;
        protected Perk perk;

        public void Initialize(Perk perk, PlayerController owner)
        {
            this.perk = perk;
            this.owner = owner;
        }

        public string GetDebugStatString()
        {
            if(perk == null||perk.Data== null)
            {
                return string.Empty;
            }

            int currentLevel, maxLevel;
            (currentLevel, maxLevel) = perk.GetLevel();

            var currentLevelData = perk.Data.GetLevelData(perk.CurrentLevel);

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendLine($"{perk.Data.Name} Modifiers (Level: {currentLevelData.PerkLevel}/{maxLevel}");

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
            Debug.Log(perk.Data.Name + " unlocked");
        }
        public void OnEquipped()
        {
            Debug.Log(perk.Data.Name + " equipped");
        }
        public void OnUnequipped()
        {
            Debug.Log(perk.Data.Name + " unequipped");
        }
        public void OnActive()
        {
            Debug.Log(perk.Data.Name + " is active");
        }
        public void OnEnhance()
        {
            Debug.Log(perk.Data.Name + " enhanced");
        }
    }
}