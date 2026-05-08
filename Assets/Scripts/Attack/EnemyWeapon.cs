using Enemy;
using Attack;
using UnityEngine;

namespace Enemy
{
    public class EnemyWeapon : Sword
    {
        protected override void OnTriggerEnter(Collider other)
        {
            other.TryGetComponent<EntityWithHealth>(out var otherEntity);
            if (otherEntity != null && selfEntity.TeamID != otherEntity.TeamID) 
            {
                Debug.Log("EnemyWeapon collided with " + other.name);   
            }
        }
    }
}