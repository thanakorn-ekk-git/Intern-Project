using Character;
using UnityEngine;

namespace Attack
{
    public class EntityWithHealth : MonoBehaviour, ICanDefend
    {
        private IContainAttributes attributes;

        public int MaxHealth = 100;
        public int CurrentHealth = 0;
        [SerializeField] private int defense;

        public int Defense => defense;

        public void Setup(IContainAttributes attributes)
        {
            this.attributes = attributes;
            this.MaxHealth = attributes.MaxHealth;
        }

        public void TakeDamage(AttackEventData attackData)
        {
            CurrentHealth -= Mathf.Max(1, attackData.Damage);
            if (CurrentHealth <= 0)
            {
                Die();
            }
        }

        protected virtual void Die()
        {
            Destroy(gameObject);
        }
    }
}