using GameManagement;
using System.Collections.Generic;
using UnityEngine;

namespace Perk
{
    public class ProjectileSpawner : MonoBehaviour
    {
        enum State { RotateAround, LinearAttack }
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

            if (modifier.ContainsKey(Perk.Modifier.RotateAround))
            {
                state = State.RotateAround;
                float radius = modifier.GetValueOrDefault(Perk.Modifier.Radius);
                int amount = modifier.GetIntOrDefault(Perk.Modifier.Amount);
                int layer = modifier.GetIntOrDefault(Perk.Modifier.Layer);

                float angleOffset = 360f / amount;

                for (int x = 0; x < layer; x++)
                {
                    float currentRadius = radius + (x * 1.5f);

                    for (int i = 0; i < amount; i++)
                    {
                        float angleToSpawn = i * angleOffset * Mathf.Deg2Rad;
                        Vector3 offsetPosition = new Vector3(Mathf.Cos(angleToSpawn), 0f, Mathf.Sin(angleToSpawn)) * currentRadius;

                        GameObject spawnedStone = Instantiate(prefab, transform.position + offsetPosition, Quaternion.identity, transform);
                        spawnedStone.transform.localRotation = new Quaternion(0f, 90f, 0f, 0f);
                        spawnedStone.transform.LookAt(transform.position);

                        if (spawnedStone.TryGetComponent<Projectile>(out var childScript))
                        {
                            childScript.Setup(this.modifier);
                        }
                    }
                }
            }
            else if (modifier.ContainsKey(Perk.Modifier.LinearAttack))
            {
                state = State.LinearAttack;
                float range = modifier.GetIntOrDefault(Perk.Modifier.Range);

                var offsetPosition = transform.forward;

                GameObject spawnedBeam = Instantiate(prefab, transform.position, Quaternion.identity, transform);
                spawnedBeam.transform.localScale = new Vector3(range, 1, 1);
            }

        }

        private void Update()
        {
            if (Time.frameCount >= duration)
            {
                Destroy(gameObject);
                return;
            }

            switch (state)
            {
                case State.RotateAround:
                    float speed = modifier.GetValueOrDefault(Perk.Modifier.Speed);
                    transform.Rotate(Vector3.up * speed * Time.deltaTime);
                    break;
            }
        }
    }
}