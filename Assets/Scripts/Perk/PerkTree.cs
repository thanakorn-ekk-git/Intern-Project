using System.Collections.Generic;

namespace Perk
{
    public class PerkTree
    {
        private List<Perk> perks = new List<Perk>();
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
                    }
                    if (perks.Count >= 2)
                    {
                        str.AppendLine("-----");
                    }
                }
            }
            return str.ToString();
        }
    }
}