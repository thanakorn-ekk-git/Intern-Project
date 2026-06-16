using GameManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Perk
{
    public class AOESpawner : MonoBehaviour
    {
        enum State { Damage, Heal }
        private State state;
        private float duration;
        private IReadOnlyDictionary<Perk.Modifier, PerkData.Modifier> modifier;

        private bool isInitialized;

        public void Setup(IReadOnlyDictionary<Perk.Modifier, PerkData.Modifier> modifiers, GameObject prefab)
        {
            if (isInitialized) return;
            isInitialized = true;

            this.modifier = modifiers;
            duration = Time.frameCount + (modifier.GetValueOrDefault(Perk.Modifier.Duration, 1f) * Application.targetFrameRate);

            float spawnDuration = modifier.GetValueOrDefault(Perk.Modifier.SpawnDuration);

            if (modifier.ContainsKey(Perk.Modifier.Damage))
            {
                state = State.Damage;
                StartCoroutine(SpawnAOECoroutine(spawnDuration, prefab));
            }
        }

        private IEnumerator SpawnAOECoroutine(float spawnDuration, GameObject prefab)
        {

            float interval = modifier.GetValueOrDefault(Perk.Modifier.SpawnInterval, 0f); 
            if (interval <= 0f)
            {
                SpawnAOEArea(prefab);
                Destroy(gameObject);
                yield break;
            }

            float duration = modifier.GetValueOrDefault(Perk.Modifier.Duration, 1f);
            float endSpawnTime = Time.frameCount + (duration * Application.targetFrameRate);

            while (Time.frameCount < endSpawnTime)
            {
                SpawnAOEArea(prefab);
                yield return new WaitForSeconds(interval);
            }

            Destroy(gameObject);
        }

        private void SpawnAOEArea(GameObject prefab)
        {
            const float raycastHeight = 20f;
            if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, raycastHeight, GameManager.Instance.LayerGround))
            {
                Debug.DrawRay(transform.position, Vector3.down, Color.green, GameManager.Instance.LayerGround);
                var aoeArea = GameObject.Instantiate(prefab, hit.point, transform.rotation);

                if (aoeArea.TryGetComponent<AOE>(out var aoeScript))
                {
                    aoeScript.Setup(modifier);
                }
            }
        }
    }
}