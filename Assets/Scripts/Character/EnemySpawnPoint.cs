using Unity.VisualScripting;
using UnityEngine;

namespace Character
{
    public class EnemySpawnPoint : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;
        public string EnemyToSpawnID => enemyToSpawnID;
        [SerializeField] public string enemyToSpawnID;
        public void SpawnEnemy(string id)
        {
            GameData.GameData.Instance.TryGetCharacter(id, out var data);
            GameObject spawnedEnemy = Instantiate(prefab, gameObject.transform.position, Quaternion.identity);
            spawnedEnemy.GetComponent<Enemy>().SetID(id);
            CharacterGameData charData = spawnedEnemy.GetComponent<CharacterGameData>();
            charData = data;

        }
    }
}