using Perk;
using UnityEditor;
using UnityEngine;

namespace Services
{
    [CustomEditor(typeof(PerkManager))]
    public class PerkSystemTester : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            var tempPerk = (PerkManager)target;

            if (Application.isPlaying)
            {
                var script = target as PerkManager;

                if (GUILayout.Button("Unlock "))
                {
                    script.TryUnlockPerk(script.PerkNameToUnlock);
                }
                if (GUILayout.Button("Activate "))
                {
                    var tmpPerkTree = script.GetPlayerPerkTree();
                    if (tmpPerkTree.PerkExist(script.PerkNameToUnlock, out Perk.Perk perk))
                    {
                        if (perk.Excutor != null)
                        {
                            perk.Excutor.OnActive();
                        }
                        else
                        {
                            Debug.LogError($"{script.PerkNameToUnlock} has invalid executor!");
                        }
                    }
                    else
                    {
                        Debug.LogError($"{script.PerkNameToUnlock} is not unlocked!");
                    }
                }
                if(GUILayout.Button("Equip"))
                {
                    var tmpPerkTree = script.GetPlayerPerkTree();
                    if (tmpPerkTree.PerkExist(script.PerkNameToUnlock, out Perk.Perk perk))
                    {
                        if (perk.Excutor != null)
                        {
                            perk.Excutor.OnEquipped();
                        }
                        else
                        {
                            Debug.LogError($"{script.PerkNameToUnlock} has invalid executor!");
                        }
                    }
                    else
                    {
                        Debug.LogError($"{script.PerkNameToUnlock} is not unlocked!");
                    }
                }
                if (GUILayout.Button("Enhance "))
                {
                    script.TryEnhancePerk(script.PerkNameToUnlock);
                }

                if (GUILayout.Button("Show Unlocked Perks"))
                {
                    var tmpPerkTree = script.GetPlayerPerkTree();
                    Debug.Log(tmpPerkTree.WhatPerkIsUnlocked());
                }
                if(GUILayout.Button("Show Perk Stats"))
                {
                    var tmpPerkTree = script.GetPlayerPerkTree();
                    if (tmpPerkTree.PerkExist(script.PerkNameToUnlock, out Perk.Perk perk))
                    {
                        Debug.Log(perk.Excutor.GetStatValue());    
                    }
                    else
                    {
                        Debug.LogError($"{script.PerkNameToUnlock} is not unlocked!");
                    }
                }
            }
        }
    }
}