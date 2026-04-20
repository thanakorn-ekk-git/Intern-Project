using NUnit;
using UnityEngine;
using static UnityEditor.Progress;

public class PerkTester : MonoBehaviour
{

    PerkData fireAttack; //Attack with fire damage
    PerkData berserk; //Increase attack damage by 50% but decrease defense by 25%
    PerkData holyGrail; //Increase health 1% per second for 20 seconds

    PerkTree perkTree = new PerkTree();

    private void Awake()
    {
        fireAttack = new PerkData.Enhancable("Fire Attack", PerkData.Tier.Tier1, false, true);
        berserk = new PerkData("Berserk", PerkData.Tier.Tier2, false, false);
        holyGrail = new PerkData("Holy Grail", PerkData.Tier.Tier3, false, true);
    }

    private void Start()
    {
        perkTree.AcquirePerk(new Perk(fireAttack));

        if (perkTree.PerkExist("Fire Attack", out Perk fireAttackOut))
        {
            print("got Fire Attack Perk");
        }
        else
        {

        }

    }

    public void UnlockPerk(string perkName)
    {
        if (perkTree.PerkExist(perkName, out Perk perkOut))
        {
            print(perkName + " is already unlocked");
            return;
        }
        else
        {
            switch(perkName)
            {
                case "Fire Attack":
                    perkTree.AcquirePerk(new Perk(fireAttack));
                    break;
                case "Berserk":
                    perkTree.AcquirePerk(new Perk(berserk));
                    break;
                case "Holy Grail":
                    perkTree.AcquirePerk(new Perk(holyGrail));
                    break;
                default:
                    print("This is not valid perk");
                    return;
            }
            print("Acquire " + perkName);
            return;
        }
    }

    public void EnhancePerk(string perkName)
    {
        if (perkTree.PerkExist(perkName, out Perk perkEnhanceOut))
        {
            if (perkEnhanceOut.Data is IEnhancablePerk enhancablePerk)
            {
                enhancablePerk.Enhance(perkEnhanceOut);
            }
            else
            {
                print(perkName + " is not enhancable");
                return;
            }
        }
        else 
        { 
            print("You have not acquied this perk"); 
        }

    }
}
