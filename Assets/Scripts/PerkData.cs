public class PerkData
{
    public class Enhancable : PerkData, IEnhancablePerk
    {
        public Enhancable(string name, Tier tier,  bool isEnhancable = false) : base(name, tier, isEnhancable = false) {
        }
        
        public void Enhance(Perk.Testing.Perk perk)
        {
            // TODO: implement enhance function
        }
    }
    public enum Tier 
    {
        Basic,
        Advanced,
        Master,
    }

    public string Name => name;
    private string name = string.Empty;
    private Tier tier = Tier.Basic;
    private bool isUnlocked = false;
    private bool isEnhancable = false;

    public PerkData(string name, Tier tier , bool isEnhanced = false)
    {
        this.name = name;
        this.tier = tier;
        this.isEnhancable = isEnhanced;
    }

    public override string ToString() 
    {
        return $"{nameof(PerkData)}:{name} {(isUnlocked ? "unlocked" : "locked")}";
    }
}
