using Player;
using System.Collections.Generic;
using UnityEngine;

namespace Perk
{
    public class PerkManager : MonoBehaviour 
    {
        [SerializeField] private PlayerController owner;
        private List<Perk> perks = new List<Perk>();

        public string PerkNameToUnlock => perkNameToUnlock;
        [SerializeField] private string perkNameToUnlock;

        public bool TryUnlockPerk(string perkName)
        {
            if (PerkExist(perkName, out Perk outPerk))
            {
                Debug.Log($"{perkName} is already unlocked!");
                return false;
            }

            if (GameData.GameData.Instance.TryGetPerk(perkName, out PerkData outData))
            {
                Perk newPerk = new Perk(outData);
                newPerk.Unlock();

                PerkExecutor excutor = BindExcutor(perkName);

                if(excutor != null)
                {
                    newPerk.SetExcutor(excutor, owner);
                    newPerk.Excutor.OnUnlocked();
                }
                ActivatePerk(newPerk);
                return true;
            }
            Debug.LogWarning($"{perkName} is invalid");
            return false;
        }

        private PerkExecutor BindExcutor(string perkName)
        {
            GameData.GameData.Instance.TryGetPerk(perkName, out PerkData perkData);
            if (perkData == null)
            {
                Debug.LogWarning($"No data found for perk: {perkName}");
                return null;
            }
            PerkExecutor executor = new PerkExecutor();

            return executor;
        }
        public bool TryEnhancePerk(string perkName)
        {
            if (PerkExist(perkName, out Perk perk))
            {
                TryEnhancePerk(perk);
                return true;
            }
            return false;
        }
        public bool TryEnhancePerk(Perk perk) 
        { 
            if (perk != null)
            {
                if (perk.Excutor != null)
                {
                    if (perk.Data.Levels.Count >= 2)
                    {
                        if(perk.CurrentLevel < perk.Data.Levels.Count)
                        {
                            perk.LevelUp();
                            perk.Excutor.OnEnhance();
                            return true;
                        }
                        Debug.LogWarning($"{perk.Data.Name} is already at max level!");
                        return false;
                    }
                    else
                    {
                        Debug.LogWarning($"{perk.Data.Name} can not be enhanced!");
                        return false;
                    }
                }
                else
                {
                    Debug.LogWarning($"{perk.Data.Name} has invalid executor!");
                    return false;
                }
            }
            else
            {
                Debug.LogWarning($"{perk.Data.Name} is not unlocked!");
                return false;
            }
        }

        public void ActivatePerk(Perk perk)
        {
            perks.Add(perk);
        }
        public bool PerkExist(string perkName, out Perk perkOut)
        {
            foreach (Perk perk in perks)
            {
                if (perkName.Equals(perk.Data.Name))
                {
                    perkOut = perk;
                    return true;
                }
            }
            perkOut = null;
            return false;
        }
        public string WhatPerkIsUnlocked()
        {
            System.Text.StringBuilder str = new System.Text.StringBuilder();
            str.AppendLine($"[PerkTree Debug] unlocked: {perks.Count} perk(s)");

            if (perks.Count == 0)
            {
                str.AppendLine("No perks unlocked.");
            }
            else
            {
                foreach (Perk perk in perks)
                {
                    if (perk.Data != null)
                    {
                        string tags = perk.Data.Tag != null ? string.Join(", ", perk.Data.Tag) : "<no_tags>";
                        str.AppendLine($"- {perk.Data.Name} (Level: {perk.CurrentLevel})");
                        str.AppendLine($"Tags: [{tags}]");
                        str.AppendLine($"Description: {perk.Data.Description}");
                        if (perks.Count >= 2)
                        {
                            str.AppendLine("-----");
                        }
                    }
                }
            }
            return str.ToString();
        }
    }
}