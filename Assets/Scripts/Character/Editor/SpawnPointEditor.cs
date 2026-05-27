using UnityEditor;
using UnityEngine;

namespace Character
{
    [CustomEditor(typeof(EnemySpawnPoint))]
    public class SpawnPointEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            if (Application.isPlaying)
            {
                var script = target as EnemySpawnPoint;
                if (GUILayout.Button("Spawn"))
                {
                    script.SpawnEnemy(script.EnemyToSpawnID);
                }
            }
        }
    }
}