using Unity.VisualScripting;
using UnityEngine;

namespace Perk.Testing
{ 
    public class PerkTester : MonoBehaviour
    {
        PerkData fireAttack; //Attack with fire damage
        PerkData berserk; //Increase attack damage by 50% but decrease defense by 25%
        PerkData holyGrail; //Increase health 1% per second for 20 seconds
        PerkTree perkTree = new PerkTree();
        private void Awake()
        {
            fireAttack = new PerkData.Enhancable("Fire Attack", PerkData.Tier.Basic, true);
            berserk = new PerkData("Berserk", PerkData.Tier.Advanced, false);
            holyGrail = new PerkData("Holy Grail", PerkData.Tier.Master, true);
        }
        private void Start()
        {
            perkTree.ActivatePerk(new Perk(fireAttack));

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
                        perkTree.ActivatePerk(new Perk(fireAttack));
                        break;
                    case "Berserk":
                        perkTree.ActivatePerk(new Perk(berserk));
                        break;
                    case "Holy Grail":
                        perkTree.ActivatePerk(new Perk(holyGrail));
                        break;
                    default:
                        print("This is not valid perk");
                        return;
                }
                print("Activate " + perkName);
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
}
