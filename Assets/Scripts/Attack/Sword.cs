using UnityEngine;

namespace Attack
{
    public class Sword : MonoBehaviour
    {
        [SerializeField] protected EntityWithHealth selfEntity;

        [SerializeField] private protected Collider weaponCollider;
        [SerializeField] private protected Attacker attacker;

        void Start()
        {
            weaponCollider.enabled = false;
        }

        protected virtual void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<EntityWithHealth>(out var defender))
            {
                AttackEventData damageInfo = new AttackEventData(attacker, defender);
                defender.TakeDamage(damageInfo);
            }
        }

        public void ActivateCollider()
        {
            weaponCollider.enabled = true;
        }
        public void DeactivateCollider()
        {
            weaponCollider.enabled = false;
        }

        protected virtual void OnAttackEnd()
        {
            // TODO : handle attack end event
        }
    }
}