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
            if (attacker != null)
            {
                if (other.TryGetComponent<EntityWithHealth>(out var otherEntity) && otherEntity.TeamID != selfEntity.TeamID)
                {
                    otherEntity.TakeDamage(attacker);
                }
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