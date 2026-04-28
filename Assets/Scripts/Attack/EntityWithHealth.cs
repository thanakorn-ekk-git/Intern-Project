using UnityEngine;

namespace Attack
{
    public class EntityWithHealth : MonoBehaviour
    {
        // TODO : Add health value
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