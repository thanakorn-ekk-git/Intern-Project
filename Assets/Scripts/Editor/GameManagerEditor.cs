using GameManagement;
using UnityEditor;
using UnityEngine;

namespace GameManagement
{
    [CustomEditor(typeof(GameManager))]
    public class GameManagerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            if (Application.isPlaying)
            {
                var script = target as GameManager;
                if (GUILayout.Button("Save"))
                {
                    GameManager.Instance.SaveGame();
                }

                if (GUILayout.Button("Load"))
                {
                    GameManager.Instance.LoadGame();
                }
            }
        }
        [MenuItem("Game/Save _F5")]
        public static void SaveGame()
        {
            if (Application.isPlaying)
            {
                GameManager.Instance.SaveGame();
                
            }
        }
    }
}