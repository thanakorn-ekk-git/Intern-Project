using Player;
using UnityEngine;

namespace Perk
{
    public abstract class PerkGameplay : MonoBehaviour
    {
        protected PerkData.Level levelData;

        public virtual void Activate(PerkData.Level level, PlayerController player)
        {
            this.levelData = level;
        }
        protected float GetModifier(Perk.Modifier modifierType, float defaultValue = 0f)
        {
            if (levelData != null && levelData.ModifiersByID.TryGetValue(modifierType, out var mod))
            {
                return mod.Value;
            }
            return defaultValue;
        }

        protected void DestroyAfterDuration()
        {
            float duration = GetModifier(Perk.Modifier.Duration);
            if (duration > 0f)
                Destroy(gameObject, duration);
            else
                Destroy(gameObject);
        }
    }

    public class StoneShield : PerkGameplay
    {
        [SerializeField] private GameObject stoneShieldPrefab;
        public override void Activate(PerkData.Level level, PlayerController player)
        {
            base.Activate(level, player);
            SpawnStones(player);
            DestroyAfterDuration();
        }

        private void SpawnStones(PlayerController player)
        {
            float radius = GetModifier(Perk.Modifier.Radius);
            int amount = (int)GetModifier(Perk.Modifier.Amount);
            int layer = (int)GetModifier(Perk.Modifier.Layer);

            var stone = new GameObject();
            stone.name = "GameObject_StoneShield";

            stone.transform.SetParent(player.transform);
            stone.transform.localPosition = Vector3.zero;

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

                    Instantiate(stoneShieldPrefab, player.transform.position + offsetPosition, Quaternion.identity, stone.transform);
                }
            }
            stone.transform.parent = player.transform;
        }

        private void Update()
        {
            float speed = GetModifier(Perk.Modifier.RotationSpeed);
            transform.Rotate(Vector3.up, speed * Time.deltaTime);
        }
    }
}