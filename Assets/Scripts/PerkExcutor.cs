using UnityEngine;

namespace Perk
{
    public abstract class PerkExcutor : MonoBehaviour
    {
        public Perk parentPerk;

        public void Initailize(Perk perk)
        {
            parentPerk = perk;
        }

        public abstract void OnUnlocked();
        public abstract void OnEquipped();
        public abstract void OnUnequipped();
        public abstract void OnUpdate();
        public abstract void OnActive();
    }

    public class BloodPumpExcute : PerkExcutor
    {
        public override void OnEquipped()
        {
            // TODO : Show unequip button
            Debug.Log("Blood Pump equipped");

            float cd = parentPerk.GetModifierValue("Cooldown");
            float duration = parentPerk.GetModifierValue("Duration");
            float buff = parentPerk.GetModifierValue("StatBuffPercentage");

            Debug.Log($"Blood Pump modifiers - Cooldown: {cd}, Duration: {duration}, Buff: {buff}");
        }
        public override void OnUnequipped()
        {
            // TODO : Show equip button
            Debug.Log("Blood Pump unequipped");
        }
        public override void OnUnlocked()
        {
            // TODO : Show equip button
        }

        public override void OnUpdate()
        {
            // TODO : Update perk visual effects
        }
        public override void OnActive()
        {
            // TODO : Buff overall user stats and consume 5% of max health as cost
            Debug.Log("Blood Pump is active");
        }
    }
}