using GameManagement;
using System.Collections.Generic;
using UnityEngine;
using Perk;

namespace Perk
{
    public class Projectile : MonoBehaviour
    {
        enum State { RotateAround }
        private State state;
        private int duration = Time.frameCount;
        private IReadOnlyDictionary<Perk.Modifier, PerkData.Modifier> modifier;

        public void Setup(IReadOnlyDictionary<Perk.Modifier, PerkData.Modifier> modifiers)
        {
            this.modifier = modifiers;
            duration = Time.frameCount + Mathf.RoundToInt(modifier.GetValueOrDefault(Perk.Modifier.Duration, 1f) * Application.targetFrameRate);

            if (modifier.ContainsKey(Perk.Modifier.RotateAround))
            {
                state = State.RotateAround;
                float radius = modifier.GetValueOrDefault(Perk.Modifier.Radius);
                int amount = modifier.GetIntOrDefault(Perk.Modifier.Amount);
                int layer = modifier.GetIntOrDefault(Perk.Modifier.Layer);

                Quaternion spawnAngle = new Quaternion(0f, 0f, 0f, 0f);
                const float zeroZ = 0f;
                Vector3 offset = new Vector3(radius, radius, zeroZ);

                float angleOffset = 360f / amount;
                for (int x = 0; x < layer; x++)
                {
                    float currentRadius = radius + (x * 1.5f);

                    for (int i = 0; i < amount; i++)
                    {
                        float angleToSpawn = i * angleOffset * Mathf.Deg2Rad;
                        Vector3 offsetPosition = new Vector3(Mathf.Cos(angleToSpawn), 0f, Mathf.Sin(angleToSpawn)) * currentRadius;
                    }
                }
            }
        }

        private void Update()
        {
            if (duration > Time.frameCount)
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