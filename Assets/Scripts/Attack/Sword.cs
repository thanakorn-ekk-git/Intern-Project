using UnityEngine;

namespace Attack
{
    public class Sword : MonoBehaviour
    {
        [SerializeField] private Collider swordCollider;
        [SerializeField] private Attacker attacker;

        void Start()
        {
            swordCollider = gameObject.GetComponent<Collider>();
            swordCollider.enabled = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<EntityWithHealth>(out var defender))
            {
                AttackEventData damageInfo = new AttackEventData(attacker, defender);
                defender.TakeDamage(damageInfo);
            }
        }

        public void ActivateCollider()
        {
            swordCollider.enabled = true;
        }
        public void DeactivateCollider()
        {
            swordCollider.enabled = false;
        }
    }
}