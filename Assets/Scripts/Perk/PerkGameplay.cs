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
        protected float GetModifier(Perk.Modifier modifierType)
        {
            if (levelData != null && levelData.ModifiersByID.TryGetValue(modifierType, out var mod))
            {
                return mod.Value;
            }
            return 0f;
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
        }

        private void Update()
        {
            float speed = GetModifier(Perk.Modifier.Speed);
            transform.Rotate(Vector3.up, speed * Time.deltaTime);
        }
    }
}