using UnityEngine;

namespace Attack
{
    public class Health : MonoBehaviour
    {
        [Range(0.1f, 200f), SerializeField] public float maxHealth = 100f;
        private float currentHealth;

        private void Start()
        {
            currentHealth = maxHealth;
        }

        public void TakeDamage()
        {
            Die();
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}
