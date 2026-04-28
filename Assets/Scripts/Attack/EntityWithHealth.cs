using UnityEngine;

namespace Attack
{
    public class EntityWithHealth : MonoBehaviour
    {
        [Range(0.1f, 200f), SerializeField] public float maxHealth = 100f;
        private float currentHealth;

        private void Start()
        {
            currentHealth = maxHealth;
        }

        public void TakeDamage(Attacker attacker)
        {
            Die();
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}
