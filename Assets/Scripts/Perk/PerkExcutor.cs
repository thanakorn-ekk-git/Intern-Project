using UnityEngine;

namespace Perk
{
    public abstract class PerkExcutor : MonoBehaviour
    {
        public Perk parentPerk;

        public void Initialize(Perk perk)
        {
            parentPerk = perk;
        }

        public abstract string GetStatValue();
        public abstract void OnUnlocked();
        public abstract void OnEquipped();
        public abstract void OnUnequipped();
        public abstract void OnUpdate();
        public abstract void OnActive();
        public abstract void OnEnhance();
    }

    public class AshenArmorExcute : PerkExcutor
    {
        public override string GetStatValue()
        {
            string level = parentPerk.GetLevel();
            float cd = parentPerk.GetModifierValue("Cooldown");
            float armor = parentPerk.GetModifierValue("ArmorPoints");
            int maxLayer = (int)parentPerk.GetModifierValue("MaxLayer");
            float explodeDamage = parentPerk.GetModifierValue("ExplodeDamage");
            bool explode = parentPerk.GetProperty("ExplodeAfterDestroyed");
            string append = $"Ashen Armor modifiers\n\tLevel: {level}\n\tCooldown: {cd}\n\tArmor Points: {armor}\n\tMax Layer: {maxLayer}\n\tExplode Damage: {explodeDamage}\n\tExplode After Destroyed: {explode}";
            return append;
        }
        public override void OnEquipped()
        {
            // TODO : Show unequip button
            Debug.Log("Ashen Armor equipped");

        }
        public override void OnUnequipped()
        {
            // TODO : Show equip button
            Debug.Log("Ashen Armor unequipped");
        }
        public override void OnUnlocked()
        {
            // TODO : Show equip button
            Debug.Log("Ashen Armor unlocked");
        }

        public override void OnUpdate()
        {
            // TODO : Update perk visual effects
        }
        public override void OnActive()
        {
            // TODO : Buff overall user stats and consume 5% of max health as cost
            Debug.Log("Ashen Armor is active");
        }
        public override void OnEnhance()
        {
            // TODO : Handle perk enhancement logic
            Debug.Log("Ashen Armor enhanced");
        }
    }
    public class BloodPumpExcute : PerkExcutor
    {
        public override string GetStatValue()
        {
            string level = parentPerk.GetLevel();
            float cd = parentPerk.GetModifierValue("Cooldown");
            float duration = parentPerk.GetModifierValue("Duration");
            float buff = parentPerk.GetModifierValue("StatBuffPercentage");
            string buffStr = $"{buff * 100}%";
            string append = $"Blood Pump modifiers\n\tLevel: {level}\n\tCooldown: {cd}\n\tDuration: {duration}\n\tBuff: {buffStr}";
            return append;
        }
        public override void OnEquipped()
        {
            // TODO : Show unequip button
        }
        public override void OnUnequipped()
        {
            // TODO : Show equip button
            Debug.Log("Blood Pump unequipped");
        }
        public override void OnUnlocked()
        {
            // TODO : Show equip button
            Debug.Log("Blood Pump unlocked");
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
        public override void OnEnhance()
        {
            // TODO : Handle perk enhancement logic
            Debug.Log("Blood Pump enhanced");
        }
    }
    public class BloodRechargeExcute : PerkExcutor
    {
        public override string GetStatValue()
        {
            string level = parentPerk.GetLevel();
            float cd = parentPerk.GetModifierValue("Cooldown");
            float bloodCost = parentPerk.GetModifierValue("BloodCost");
            float lowerHealthThreshold = parentPerk.GetModifierValue("CostThreshold");
            string append = $"Blood Recharge modifiers\n\tLevel: {level}\n\tCooldown: {cd}\n\tBlood Cost: {bloodCost * 100}%\n\tLower Health Threshold: {lowerHealthThreshold}";
            return append;
        }
        public override void OnEquipped()
        {
            // TODO : Show unequip button
            Debug.Log("Blood Recharge equipped");
        }
        public override void OnUnequipped()
        {
            // TODO : Show equip button
            Debug.Log("Blood Recharge unequipped");
        }
        public override void OnUnlocked()
        {
            // TODO : Show equip button
            Debug.Log("Blood Recharge unlocked");
        }
        public override void OnUpdate()
        {
            // TODO : Update perk visual effects
        }
        public override void OnActive()
        {
            // TODO : Buff overall user stats and consume 5% of max health as cost
            Debug.Log("Blood Recharge is active");
        }
        public override void OnEnhance()
        {
            // TODO : Handle perk enhancement logic
            Debug.Log("Blood Recharge enhanced");
        }
    }
    public class EchoBlowExcute : PerkExcutor
    {
        public override string GetStatValue()
        {
            string level = parentPerk.GetLevel();
            float cd = parentPerk.GetModifierValue("Cooldown");
            float duration = parentPerk.GetModifierValue("Duration");
            float damage = parentPerk.GetModifierValue("Damage");
            float radius = parentPerk.GetModifierValue("Radius");
            string append = $"Echo Blow modifiers\n\tLevel: {level}\n\tCooldown: {cd}\n\tDuration: {duration}\n\tDamage: {damage}\n\tRadius: {radius}";
            return append;
        }
        public override void OnEquipped()
        {
            // TODO : Show unequip button
            Debug.Log("Echo Blow equipped");
        }
        public override void OnUnequipped()
        {
            // TODO : Show equip button
            Debug.Log("Echo Blow unequipped");
        }
        public override void OnUnlocked()
        {
            // TODO : Show equip button
            Debug.Log("Echo Blow unlocked");
        }
        public override void OnUpdate()
        {
            // TODO : Update perk visual effects
        }
        public override void OnActive()
        {
            // TODO : Buff overall user stats and consume 5% of max health as cost
            Debug.Log("Echo Blow is active");
        }
        public override void OnEnhance()
        {
            // TODO : Handle perk enhancement logic
            Debug.Log("Echo Blow enhanced");
        }
    }
    public class FireDashExcute : PerkExcutor
    {
        public override string GetStatValue()
        {
            string level = parentPerk.GetLevel();
            float cd = parentPerk.GetModifierValue("Cooldown");
            float duration = parentPerk.GetModifierValue("Duration");
            float damage = parentPerk.GetModifierValue("Damage");
            float trailDamage = parentPerk.GetModifierValue("TrailDamage");
            string append = $"Fire Dash modifiers\n\tLevel: {level}\n\tCooldown: {cd}\n\tDuration: {duration}\n\tDamage: {damage}\n\tTrail Damage: {trailDamage}";
            return append;
        }
        public override void OnEquipped()
        {
            // TODO : Show unequip button
            Debug.Log("Fire Dash equipped");
        }
        public override void OnUnequipped()
        {
            // TODO : Show equip button
            Debug.Log("Fire Dash unequipped");
        }
        public override void OnUnlocked()
        {
            // TODO : Show equip button
            Debug.Log("Fire Dash unlocked");
        }

        public override void OnUpdate()
        {
            // TODO : Update perk visual effects
        }
        public override void OnActive()
        {
            // TODO : Buff overall user stats and consume 5% of max health as cost
            Debug.Log("Fire Dash is active");
        }
        public override void OnEnhance()
        {
            // TODO : Handle perk enhancement logic
            Debug.Log("Fire Dash enhanced");
        }
    }
}