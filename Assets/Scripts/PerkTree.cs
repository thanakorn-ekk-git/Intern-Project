using NUnit;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class PerkTree
{




    private List<Perk> perks = new List<Perk>();


    public void AcquirePerk(Perk perk)
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
        string str = $"{nameof(PerkTree)} have {perks.Count} unlocked perks";
        foreach (Perk perk in perks)
        {
            str += "\n -> " + perk.UUID + ":" + perk.Data.WhatIsThis();
        }
        return str;
    }
}
