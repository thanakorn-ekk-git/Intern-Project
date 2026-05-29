using UnityEditor;

namespace Items
{
    [CustomEditor(typeof(Item))]
    public class ItemEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            var item = (Item)target;

            if (item != null && item.Data is ItemGameData data)
            {
                EditorGUILayout.TextArea(data.ToString());
            }
        }
    }
}