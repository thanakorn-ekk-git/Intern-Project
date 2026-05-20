using Character;
using UnityEngine;

namespace Attack
{
    public class EntityWithHealth : MonoBehaviour, IDefendable
    {
        private IContainAttributes attributes;

        private int MaxHealth = 100;
        public int CurrentHealth = 0;
        [SerializeField] private int defense;

        public int Defense => defense;

        public void SetData(int defense)
        {
            this.defense = defense;
        }

        public void TakeDamage(AttackEventData attackData)
        {
            CurrentHealth -= attackData.Damage;
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