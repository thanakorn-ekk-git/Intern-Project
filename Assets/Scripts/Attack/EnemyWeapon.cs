using Enemy;
using UnityEngine;

namespace Attack
{
    public class EnemyWeapon : Sword
    {
        void Start()
        {
            weaponCollider = gameObject.GetComponent<Collider>();
            weaponCollider.enabled = false;
        }

        void Update()
        {

        }
    }
}