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
        public abstract void OnUpdate();
        public virtual void OnUnlocked(string str)
        {
            Debug.Log(str + " unlocked");
        }
        public virtual void OnEquipped(string str)
        {
            Debug.Log(str + " equipped");
        }
        public virtual void OnUnequipped(string str)
        {
            Debug.Log(str + " unequipped");
        }
        public virtual void OnActive(string str)
        {
            Debug.Log(str + " is active");
        }
        public virtual void OnEnhance(string str)
        {
            Debug.Log(str + " enhanced");
        }
    }

    public class AshenArmorExcute : PerkExcutor
    {
        public override string GetStatValue()
        {
            string level = parentPerk.GetLevel();
            float cd = parentPerk.GetModifierValue("Cooldown");
            float duration = parentPerk.GetModifierValue("Duration");
            float armor = parentPerk.GetModifierValue("ArmorPoints");
            int maxLayer = (int)parentPerk.GetModifierValue("MaxLayer");
            float explodeDamage = parentPerk.GetModifierValue("ExplodeDamage");
            bool explode = parentPerk.GetProperty("ExplodeAfterDestroyed");
            string append = $"Ashen Armor modifiers\n\tLevel: {level}\n\tCooldown: {cd}\n\tDuration: {duration}\n\tArmor Points: {armor}\n\tMax Layer: {maxLayer}\n\tExplode Damage: {explodeDamage}\n\tExplode After Destroyed: {explode}";
            return append;
        }
        public override void OnUpdate()
        {
            // TODO : if( eliminated enemy ) { get ash barrier }
        }
        public override void OnEquipped(string str)
        {
            // TODO : Show unequip button
            base.OnEquipped("Ashen Armor");

        }
        public override void OnUnequipped(string str)
        {
            // TODO : Show equip button
            base.OnUnequipped("Ashen Armor");
        }
        public override void OnUnlocked(string str)
        {
            // TODO : Show equip button
            base.OnUnlocked("Ashen Armor");
        }
        public override void OnActive(string str)
        {
            // TODO : start cooldown
            // TODO : start counting duration
            base.OnActive("Ashen Armor");
        }
        public override void OnEnhance(string str)
        {
            // TODO : Handle perk enhancement logic
            base.OnEnhance("Ashen Armor");
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
            float bloodCost = parentPerk.GetModifierValue("BloodCost");
            string append = $"Blood Pump modifiers\n\tLevel: {level}\n\tCooldown: {cd}\n\tDuration: {duration}\n\tBuff: {buffStr}\n\tBlood Cost: {bloodCost * 100}%";
            return append;
        }
        public override void OnUpdate()
        {
            // TODO : Update perk visual effects
        }
        public override void OnEquipped(string str)
        {
            // TODO : Show unequip button
            base.OnEquipped("Blood Pump");
        }
        public override void OnUnequipped(string str)
        {
            // TODO : Show equip button
            base.OnUnequipped("Blood Pump");
        }
        public override void OnUnlocked(string str)
        {
            // TODO : Show equip button
            base.OnUnlocked("Blood Pump");
        }
        public override void OnActive(string str)
        {
            // TODO : Buff overall user stats and consume 5% of max health as cost
            // TODO : start cooldown
            // TODO : start counting duration
            base.OnActive("Blood Pump");
        }
        public override void OnEnhance(string str)
        {
            // TODO : Handle perk enhancement logic
            base.OnEnhance("Blood Pump");
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
        public override void OnUpdate()
        {
            // NO UPDATE //
        }
        public override void OnEquipped(string str)
        {
            // TODO : Show unequip button
            base.OnEquipped("Blood Recharge");
        }
        public override void OnUnequipped(string str)
        {
            // TODO : Show equip button
            base.OnUnequipped("Blood Recharge");
        }
        public override void OnUnlocked(string str)
        {
            // TODO : Show equip button
            base.OnUnlocked("Blood Recharge");
        }
        public override void OnActive(string str)
        {
            // TODO : Reset all perks cooldown and consume 5% of max health as cost
            // TODO : start cooldown
            // TODO : start counting duration
            base.OnActive("Blood Recharge");
        }
        public override void OnEnhance(string str)
        {
            // TODO : Handle perk enhancement logic
            base.OnEnhance("Blood Recharge");
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
        public override void OnUpdate()
        {
            // TODO : if ( user attack ) { spawn echo that attack nearby enemies with reduced damage } 
        }
        public override void OnEquipped(string str)
        {
            // TODO : Show unequip button
            base.OnEquipped("Echo Blow");
        }
        public override void OnUnequipped(string str)
        {
            // TODO : Show equip button
            base.OnUnequipped("Echo Blow");
        }
        public override void OnUnlocked(string str)
        {
            // TODO : Show equip button
            base.OnUnlocked("Echo Blow");
        }
        public override void OnActive(string str)
        {
            // TODO : Buff overall user stats and consume 5% of max health as cost
            // TODO : start cooldown
            // TODO : start counting duration
            base.OnActive("Echo Blow");
        }
        public override void OnEnhance(string str)
        {
            // TODO : Handle perk enhancement logic
            base.OnEnhance("Echo Blow");
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
        public override void OnUpdate()
        {
            // TODO : move the user forward and damage enemies on the way
        }
        public override void OnEquipped(string str)
        {
            // TODO : Show unequip button
            base.OnEquipped("Fire Dash");
        }
        public override void OnUnequipped(string str)
        {
            // TODO : Show equip button
            base.OnUnequipped("Fire Dash");
        }
        public override void OnUnlocked(string str)
        {
            // TODO : Show equip button
            base.OnUnlocked("Fire Dash");
        }

        public override void OnActive(string str)
        {
            // TODO : start cooldown
            // TODO : start counting duration
            base.OnActive("Fire Dash");
        }
        public override void OnEnhance(string str)
        {
            // TODO : Handle perk enhancement logic
            base.OnEnhance("Fire Dash");
        }
    }
    public class FrostBeamExcute : PerkExcutor
    {
        public override string GetStatValue()
        {
            string level = parentPerk.GetLevel();
            float cd = parentPerk.GetModifierValue("Cooldown");
            float freezeDuration = parentPerk.GetModifierValue("FreezeDuration");
            float slowDuration = parentPerk.GetModifierValue("SlowDuration");
            float slowPercentage = parentPerk.GetModifierValue("SlowPercentage");
            float range = parentPerk.GetModifierValue("Range");
            string append = $"Frost Beam modifiers\n\tLevel: {level}\n\tCooldown: {cd}\n\tFreeze Duration: {freezeDuration}\n\tSlow Duration: {slowDuration}\n\tSlow Percentage: {slowPercentage * 100}%\n\tRange: {range}";
            return append;
        }
        public override void OnUpdate()
        {
            // NO UPDATE //
        }
        public override void OnEquipped(string str)
        {
            // TODO : Show unequip button
            base.OnEquipped("Frost Beam");
        }
        public override void OnUnequipped(string str)
        {
            // TODO : Show equip button
            base.OnUnequipped("Frost Beam");
        }
        public override void OnUnlocked(string str)
        {
            // TODO : Show equip button
            base.OnUnlocked("Frost Beam");
        }
        public override void OnActive(string str)
        {
            // TODO : shoot a frost beam
            // TODO : start cooldown
            base.OnActive("Frost Beam");
        }
        public override void OnEnhance(string str)
        {
            // TODO : Handle perk enhancement logic
            base.OnEnhance("Frost Beam");
        }
    }

    public class HeavyStrikeExcute : PerkExcutor
    {
        public override string GetStatValue()
        {
            string level = parentPerk.GetLevel();
            float cd = parentPerk.GetModifierValue("Cooldown");
            float damage = parentPerk.GetModifierValue("Damage");
            float duration = parentPerk.GetModifierValue("Duration");
            string append = $"Heavy Strike modifiers\n\tLevel: {level}\n\tCooldown: {cd}\n\tDamage: {damage}\n\tDuration: {duration}";
            return append;
        }
        public override void OnUpdate()
        {
            // TODO : if ( user attack ) { deal extra damage to the enemy }
        }
        public override void OnEquipped(string str)
        {
            // TODO : Show unequip button
            base.OnEquipped("Heavy Strike");
        }
        public override void OnUnequipped(string str)
        {
            // TODO : Show equip button
            base.OnUnequipped("Heavy Strike");
        }
        public override void OnUnlocked(string str)
        {
            // TODO : Show equip button
            base.OnUnlocked("Heavy Strike");
        }
        public override void OnActive(string str)
        {
            // TODO : start cooldown
            // TODO : start counting duration
            base.OnActive("Heavy Strike");
        }
        public override void OnEnhance(string str)
        {
            // TODO : Handle perk enhancement logic
            base.OnEnhance("Heavy Strike");
        }
    }

    public class LastBreathExcute : PerkExcutor
    {
        public override string GetStatValue()
        {
            string level = parentPerk.GetLevel();
            float cd = parentPerk.GetModifierValue("Cooldown");
            float duration = parentPerk.GetModifierValue("Duration");
            float damageTakenDuration = parentPerk.GetModifierValue("DamageTakenDuration");
            float damageTakenPercentage = parentPerk.GetModifierValue("DamageTakenPercentage");
            string append = $"Last Breath modifiers\n\tLevel: {level}\n\tCooldown: {cd}\n\tDuration: {duration}\n\tDamage Taken Duration: {damageTakenDuration}\n\tDamage Taken Percentage: {damageTakenPercentage}";
            return append;
        }
        public override void OnUpdate()
        {
            // TODO : if ( taken damage ) { reject damage and store }
            // TODO : if ( store damage > 0 ) { apply damage * (damageTakenPercentage) }
        }
        public override void OnEquipped(string str)
        {
            // TODO : Show unequip button
            base.OnEquipped("Last Breath");
        }
        public override void OnUnequipped(string str)
        {
            // TODO : Show equip button
            base.OnUnequipped("Last Breath");
        }
        public override void OnUnlocked(string str)
        {
            // TODO : Show equip button
            base.OnUnlocked("Last Breath");
        }
        public override void OnActive(string str)
        {
            // TODO : Buff overall user stats and consume 5% of max health as cost
            base.OnActive("Last Breath");
        }
        public override void OnEnhance(string str)
        {
            // TODO : Handle perk enhancement logic
            base.OnEnhance("Last Breath");
        }
    }
    public class StoneShieldExcute : PerkExcutor
    {
        public override string GetStatValue()
        {
            string level = parentPerk.GetLevel();
            float cd = parentPerk.GetModifierValue("Cooldown");
            float duration = parentPerk.GetModifierValue("Duration");
            float radius = parentPerk.GetModifierValue("Radius");
            float amount = parentPerk.GetModifierValue("Amount");
            int layer = (int)parentPerk.GetModifierValue("Layer");
            string append = $"Stone Shield modifiers\n\tLevel: {level}\n\tCooldown: {cd}\n\tDuration: {duration}\n\tRadius: {radius}\n\tAmount: {amount}\n\tLayer: {layer}";
            return append;
        }
        public override void OnUpdate()
        {
            // TODO : float the stone shields around the user
        }
        public override void OnEquipped(string str)
        {
            // TODO : Show unequip button
            base.OnEquipped("Stone Shield");
        }
        public override void OnUnequipped(string str)
        {
            // TODO : Show equip button
            base.OnUnequipped("Stone Shield");
        }
        public override void OnUnlocked(string str)
        {
            // TODO : Show equip button
            base.OnUnlocked("Stone Shield");
        }
        public override void OnActive(string str)
        {
            // TODO : summon stone shields floating around the user that block incoming damage
            base.OnActive("Stone Shield");
        }
        public override void OnEnhance(string str)
        {
            // TODO : Handle perk enhancement logic
            base.OnEnhance("Stone Shield");
        }
    }
}