using UnityEditor;
using UnityEngine;

namespace Services
{
    [CustomEditor(typeof(FileHandler))]
    public class FileHandlerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            if (Application.isPlaying)
            {
                var script = target as FileHandler;
                if (GUILayout.Button("Save"))
                {
                    script.Save();
                }

                if (GUILayout.Button("Load"))
                {
                    script.LoadSaveData();
                }
            }
        }
    }
}