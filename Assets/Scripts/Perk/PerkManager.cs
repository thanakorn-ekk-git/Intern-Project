using Player;
using System.Collections.Generic;

namespace Perk
{
    public class PerkManager
    {
        private PlayerController owner;
        private Dictionary<string, Perk> perks = new Dictionary<string, Perk>();
        public IReadOnlyDictionary<string, Perk> Unlocked => perks;

        public string PerkNameToUnlock => perkNameToUnlock;
        private string perkNameToUnlock;

        public PerkManager(PlayerController owner)
        {
            this.owner = owner;
        }

        public bool TryUnlockPerk(PerkData data)
        {
            Perk newPerk = new Perk(data);
            newPerk.LevelUp();

            AddPerk(newPerk);
            return true;
        }
        public bool TryUnlockPerk(string perkID)
        {
            if(GameData.GameData.Instance.TryGetPerk(perkID, out var data))
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
            return true;
        }

        public void AddPerk(Perk perk)
        {
            perks.Add(perk.Data.ID, perk);
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