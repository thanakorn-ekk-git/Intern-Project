using UnityEngine;

namespace Attack
{
    public class Sword : MonoBehaviour
    {
        [SerializeField] private protected Collider weaponCollider;
        [SerializeField] private protected Attacker attacker;

        void Start()
        {
            weaponCollider = gameObject.GetComponent<Collider>();
            weaponCollider.enabled = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<EntityWithHealth>(out var health))
            {
                if (attacker != null)
                {
                    health.TakeDamage(attacker);
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
    }
}