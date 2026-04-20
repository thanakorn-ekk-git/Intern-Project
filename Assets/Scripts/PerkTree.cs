using System;
using System.Collections.Generic;
using UnityEngine;

public class PerkTree
{
    private List<Perk.Testing.Perk> perks = new List<Perk.Testing.Perk>();
    public void ActivatePerk(Perk.Testing.Perk perk)
    {
        perks.Add(perk);
    }
    public bool PerkExist(string perkName, out Perk.Testing.Perk perkOut)
    {
        foreach (Perk.Testing.Perk perk in perks)
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
        foreach (Perk.Testing.Perk perk in perks)
        {
            str += "\n -> " + perk.UUID + ":" + perk.Data.ToString();
        }
        return str;
    }
}
