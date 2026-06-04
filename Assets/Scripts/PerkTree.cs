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
        public void UnlockPerk()
        {

        }
    }
}