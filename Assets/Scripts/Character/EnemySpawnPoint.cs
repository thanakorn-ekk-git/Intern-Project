using UnityEngine;

namespace Character
{
    public class EnemySpawnPoint : MonoBehaviour
    {
        public string EnemyNameToSpawn => enemyNameToSpawn;
        [SerializeField] private string enemyNameToSpawn;
        public void SpawnEnemy(string prefabName)
        {
            string resourcePath = $"Prefabs/Enemies/{prefabName}";

            var prefab = Resources.Load<GameObject>(resourcePath);
            if(prefab == null )
            {
                Debug.LogError($"Prefab not found! error at: Resources/{resourcePath}");
                return;
            }
            var spawnedEnemy = GameObject.Instantiate(prefab, gameObject.transform.position, Quaternion.identity);
            spawnedEnemy.name = prefabName;

            // TODO : add SetID() logics so enemy can be initialized correctly
        }
    }
}