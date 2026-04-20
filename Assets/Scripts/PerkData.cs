using NUnit.Framework.Interfaces;
using UnityEngine;
using static PerkData;

public class PerkData
{
    public class Enhancable : PerkData, IEnhancablePerk
    {
        public Enhancable(string name, Tier tier, bool isUnlocked = false, bool isEnhancable = false) : base(name, tier, isUnlocked = false, isEnhancable = false) {
        }
        public void Enhance(Perk perk)
        {
            Debug.Log("Enhance "  + Name + " perk");
        }
    }
    public enum Tier 
    {
        Tier1,
        Tier2,
        Tier3,
    }

    public string Name => name;
    private string name = string.Empty;
    private Tier tier = Tier.Tier1;
    private bool isUnlocked = false;
    private bool isEnhancable = false;

    public PerkData(string name, Tier tier , bool isUnlocked = false, bool isEnhanced = false)
    {
        this.name = name;
        this.tier = tier;
        this.isUnlocked = isUnlocked;
        this.isEnhancable = isEnhanced;
    }

    public string WhatIsThis() 
    {
        return $"{nameof(PerkData)}:{name} {(isUnlocked ? "unlocked" : "locked")}";
    }
}
