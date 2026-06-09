using Player;
using System.Collections.Generic;
using UnityEngine;

namespace Perk
{
    public class PerkManager
    {
        private PlayerController owner;
        private List<Perk> perks = new List<Perk>();

        public string PerkNameToUnlock => perkNameToUnlock;
        private string perkNameToUnlock;

        public PerkManager(PlayerController owner)
        {
            this.owner = owner;
        }

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
                newPerk.LevelUp();

                PerkExecutor excutor = BindExcutor(perkName);

                if(excutor != null)
                {
                    newPerk.SetExecutor(excutor, owner);
                    newPerk.Executor.OnUnlocked();
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
            if (perk == null)
            { 
                return false;            
            }
            if (perk.Executor == null)
            {
                return false;
            }
            if (perk.Data.Levels.Count >= 2)
            {
                return false;
            }
            if (perk.CurrentLevel >= perk.Data.Levels.Count)
            {
                return false;
            }

            perk.LevelUp();
            perk.Executor.OnEnhance();
            return true;
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

        public IReadOnlyDictionary<string, Perk> GetUnlockedPerk()
        {
            Dictionary<string, Perk> unlockedPerksDict = new Dictionary<string, Perk>();

            if (perks != null)
            {
                foreach(Perk perk in perks)
                {
                    if (perk != null && perk.Data != null) 
                    {
                        unlockedPerksDict.Add(perk.Data.Name, perk);
                    }
                }
            }
            return unlockedPerksDict;
        }
    }
}