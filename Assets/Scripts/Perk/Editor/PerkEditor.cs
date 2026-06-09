using UnityEditor;
using UnityEngine;
using Player;

namespace Perk
{
    [CustomEditor(typeof(PlayerController))]
    public class PerkSystemTester : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            var player = target as PlayerController;
            if (player == null) return;

            if (Application.isPlaying)
            {
                var script = player.PerkManager;
                if (script == null) return;

                if (GUILayout.Button("Unlock "))
                {
                    script.TryUnlockPerk(player.PerkNameToUnlock);
                }
                if (GUILayout.Button("Activate "))
                {
                    if (script.PerkExist(player.PerkNameToUnlock, out Perk perk))
                    {
                        if (perk.Executor != null)
                        {
                            perk.Executor.OnActive();
                        }
                        else
                        {
                            Debug.LogError($"{player.PerkNameToUnlock} has invalid executor!");
                        }
                    }
                    else
                    {
                        Debug.LogError($"{player.PerkNameToUnlock} is not unlocked!");
                    }
                }
                if(GUILayout.Button("Equip"))
                {
                    if (script.PerkExist(player.PerkNameToUnlock, out Perk perk))
                    {
                        if (perk.Executor != null)
                        {
                            perk.Executor.OnEquipped();
                        }
                        else
                        {
                            Debug.LogError($"{player.PerkNameToUnlock} has invalid executor!");
                        }
                    }
                    else
                    {
                        Debug.LogError($"{player.PerkNameToUnlock} is not unlocked!");
                    }
                }
                if (GUILayout.Button("Enhance "))
                {
                    script.TryEnhancePerk(player.PerkNameToUnlock);
                }

                if (GUILayout.Button("Show Perk Stats"))
                {
                    if (script.PerkExist(player.PerkNameToUnlock, out Perk perk))
                    {
                        if (perk.Executor != null)
                        {
                            Debug.Log(perk.Executor.GetDebugStatString());
                        }
                        else
                        {
                            Debug.LogError($"{player.PerkNameToUnlock} has an invalid or null executor!");
                        }
                    }
                    else
                    {
                        Debug.LogError($"{player.PerkNameToUnlock} is not unlocked!");
                    }
                }
                if (GUILayout.Button("Show All Unlocked Perks"))
                {
                    Debug.Log(script.GetUnlockedPerk());
                }
            }
        }
    }
}