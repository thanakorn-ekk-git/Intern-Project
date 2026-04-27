using UnityEngine;

namespace Attack
{
    public class Sword : MonoBehaviour
    {
        Collider swordCollider;
        void Start()
        {
            swordCollider = gameObject.GetComponent<Collider>();
            swordCollider.enabled = false;
        }

        void Update()
        {

        }
        private void OnTriggerEnter(Collider other)
        {
            other.GetComponent<Health>()?.TakeDamage();
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
