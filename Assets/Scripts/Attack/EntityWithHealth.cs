using Character;
using UnityEngine;

namespace Attack
{
    public class EntityWithHealth : MonoBehaviour, IDefendable
    {
        private IContainAttributes attributes;

        private int maxHealth = 100;
        private int currentHealth = 0;
        private int defense;

        public int Defense => defense;

        public void SetData(int defense, int maxHealth)
        {
            this.maxHealth = maxHealth;
            this.defense = defense;
            currentHealth = this.maxHealth;
        }

        public void TakeDamage(AttackEventData attackData)
        {
            currentHealth -= attackData.Damage;
            if (currentHealth <= 0)
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