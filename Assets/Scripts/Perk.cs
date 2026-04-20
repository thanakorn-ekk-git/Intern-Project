using System.Collections.Generic;
using UnityEngine;

namespace Perk.Testing
{
    public class Perk
    {
        private List<int> perkIDs = new List<int>();

        public PerkData Data => data;
        PerkData data;

        public readonly int UUID;
        public bool isUnlocked = false;

        public Perk(PerkData data)
        {
            this.data = data;
            UUID = Random.Range(001, 100);
            while (perkIDs.Contains(UUID))
            {
                UUID += 1;
            }
            perkIDs.Add(UUID);
        }
    }
}
