using UnityEngine;

namespace Attack
{
    public class EntityWithHealth : MonoBehaviour
    {
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
