using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class EnemyPrefabManager : MonoBehaviour
    {
        public static EnemyPrefabManager Instance => GameManagement.GameManager.Instance.enemyPrefabManager;

        [SerializeField] private List<GameObject> enemyPrefabs;

        private Dictionary<string, GameObject> prefabDictionary;

        private void Awake()
        {
            prefabDictionary = new Dictionary<string, GameObject>();

            foreach (var prefab in enemyPrefabs)
            {
                if (prefab!= null && !prefabDictionary.ContainsKey(prefab.name))
                {
                    prefabDictionary.Add(prefab.name, prefab);
                }                
            }
        }

        public GameObject GetEnemyPrefab(string prefabName)
        {
            if (prefabDictionary.TryGetValue(prefabName, out var prefab))
            {
                return prefab;
            }
            return null;
        }

    }
}