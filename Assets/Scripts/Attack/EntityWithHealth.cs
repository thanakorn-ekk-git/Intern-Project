using Unity.VisualScripting;
using UnityEngine;

namespace Attack
{
    public class EntityWithHealth : MonoBehaviour
    {
        public int TeamID => teamID;
        [SerializeField] private int teamID = 0;
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