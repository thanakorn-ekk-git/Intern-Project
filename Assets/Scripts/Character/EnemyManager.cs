using UnityEngine;

namespace Character
{
    public class EnemyManager : MonoBehaviour
    {
        private EnemySpawnPoint[] spawnPoints;

        private void Start()
        {
            spawnPoints = GameObject.FindObjectsByType<EnemySpawnPoint>(sortMode:FindObjectsSortMode.None);
        }
    }
}