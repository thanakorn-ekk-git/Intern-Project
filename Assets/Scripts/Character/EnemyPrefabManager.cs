using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class EnemyPrefabManager : MonoBehaviour
    {
        public static EnemyPrefabManager Instance => GameManagement.GameManager.Instance.EnemyPrefabManager;

        [SerializeField] private List<Enemy> prefabs;

        private Dictionary<string, Enemy> prefabByIDs;

        public bool TryGetEnemy(string id, out Enemy enemy)
        {
            Cache();
            return prefabByIDs.TryGetValue(id, out enemy);
        }
        
        private void Cache()
        {
            if (prefabByIDs != null)
            {
                return;
            }
            foreach (var prefab in prefabs)
            {
                prefabByIDs.TryAdd(prefab.name, prefab);
            }
        }

    }
}