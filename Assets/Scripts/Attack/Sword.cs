using UnityEngine;

namespace Attack
{
    public class Sword : MonoBehaviour
    {
        [SerializeField] private Collider swordCollider;

        private Attacker attacker;

        void Start()
        {
            swordCollider = gameObject.GetComponent<Collider>();
            swordCollider.enabled = false;
            attacker = gameObject.GetComponentInParent<Attacker>();
        }

        void Update()
        {

        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<EntityWithHealth>(out var health))
            {
                health.TakeDamage(attacker);
            }
            print(other.gameObject.name);
        }
        public void ActivateCollider()
        {
            swordCollider.enabled = true;
            print("Collider Activated");
        }
        public void DeactivateCollider()
        {
            swordCollider.enabled = false;
            print("Collider Deactivated");
        }
    }
}
