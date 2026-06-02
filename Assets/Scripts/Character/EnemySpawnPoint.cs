using UnityEngine;

namespace Character
{
    public class EnemySpawnPoint : MonoBehaviour
    {
        public string EnemyNameToSpawn => enemyNameToSpawn;
        [SerializeField] private string enemyNameToSpawn;
        public void SpawnEnemy(string prefabName)
        {
            var prefab = EnemyPrefabManager.Instance.GetEnemyPrefab(prefabName);
            if(prefab == null )
            {
                Debug.LogError($"Prefab not found! error at EnemyPrefabManager: {prefabName}");
                return;
            }
            var spawnedEnemy = GameObject.Instantiate(prefab, gameObject.transform.position, Quaternion.identity);
            spawnedEnemy.name = prefabName;

            // TODO : add SetID() logics so enemy can be initialized correctly
        }
    }
}