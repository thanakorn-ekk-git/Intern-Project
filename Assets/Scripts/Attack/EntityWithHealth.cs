using UnityEngine;

namespace Attack
{
    public class EntityWithHealth : MonoBehaviour
    {
        public int health = 100;
        // TODO : Add health value
        public void TakeDamage(Attacker attacker)
        {
            health -= attacker.Damage;
            if (health <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}