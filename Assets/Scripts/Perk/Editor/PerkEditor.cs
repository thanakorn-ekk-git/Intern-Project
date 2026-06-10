using UnityEditor;
using UnityEngine;
using Player;

namespace Perk
{
    [CustomEditor(typeof(PlayerController))]
    public class PerkSystemTester : Editor
    {
        string text = "Perk ID to Unlock";
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            text = GUILayout.TextArea(text);

            var player = target as PlayerController;
            if (player == null) return;

            if (Application.isPlaying)
            {
                var script = player.PerkManager;
                if (script == null) return;

                if (GUILayout.Button("Unlock "))
                {
                    script.TryUnlockPerk(text);
                }
                if (GUILayout.Button("Activate "))
                {
                    if(script.Unlocked.TryGetValue(text, out var perk))
                        perk.OnActive();
                }
                if(GUILayout.Button("Equip"))
                {
                    if (script.Unlocked.TryGetValue(text, out var perk))

                        perk.OnEquipped();
                }
                if (GUILayout.Button("Enhance "))
                {
                    script.TryEnhancePerk(text);
                }

                if (GUILayout.Button("Show Perk Stats"))
                {
                    if (script.Unlocked.TryGetValue(text, out var perk))
                        Debug.Log(perk.Data.GetDebugStatString());
                }
                if (GUILayout.Button("Show All Unlocked Perks"))
                {
                    foreach( var (_,perk) in script.Unlocked)
                    Debug.Log(perk.Data.ID);
                }
            }
        }
    }
}