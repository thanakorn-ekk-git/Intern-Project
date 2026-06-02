using UnityEditor;

namespace Character
{
    [CustomEditor(typeof(Enemy))]
    public class EnemyEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            var enemy = (Enemy)target;

            if (enemy != null && enemy.Data is CharacterGameData data)
            {
                EditorGUILayout.TextArea(data.ToStringEnemy());
            }
        }
    }
}