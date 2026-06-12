using GameManagement;
using Player;
using System.Collections.Generic;

namespace Perk
{
    public class PerkManager
    {
        public PlayerController Owner { get; private set; }
        private Dictionary<string, Perk> perks = new Dictionary<string, Perk>();
        public IReadOnlyDictionary<string, Perk> Unlocked => perks;

        public string PerkNameToUnlock => perkNameToUnlock;
        private string perkNameToUnlock;

        public Perk[] Slot { get; private set; } = new Perk[4];
        

        public PerkManager(PlayerController owner)
        {
            this.Owner = owner;
        }

        public bool CastPerk(int perkIndex)
        {
            var selectedPerk = Slot[perkIndex];
            if (selectedPerk == null) return false;
            if (!selectedPerk.CanCast(this)) return false;

            selectedPerk.Cast(this);
            return true;
        }

        public bool TryUnlockPerk(PerkData data)
        {
            Perk newPerk = new Perk(data);

            AddPerk(newPerk);
            return true;
        }
        public bool TryUnlockPerk(string perkID)
        {
            if (GameData.GameData.Instance.TryGetPerk(perkID, out var data))
            {
                TryUnlockPerk(data);
                return true;
            }
            return false;
        }

        public bool TryEnhancePerk(string perkID)
        {
            if (perks.TryGetValue(perkID, out Perk perk))
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
            if (perk.Data.Levels.Length >= 2)
            {
                return false;
            }
            if (perk.CurrentLevel >= perk.Data.Levels.Length)
            {
                return false;
            }

            perk.LevelUp();
            GameManager.Instance.PlayerData.UpdateValue(this);
            return true;
        }

        public void AddPerk(Perk perk)
        {
            perks.Add(perk.Data.ID, perk);
            perk.LevelUp();
            for(int i = 0; i < Slot.Length; i++)
            {
                if(Slot[i] == null)
                {
                    Slot[i] = perk;
                    break;
                }
            }
            GameManager.Instance.PlayerData.UpdateValue(this);
        }
        public bool IsUnlockable(PerkData data)
        {
            if (data.RequiredPerks.Length == 0) return true;
            foreach (var req in data.RequiredPerks)
            {
                if (!perks.ContainsKey(req)) return false;
            }
            return true;
        }
    }
}