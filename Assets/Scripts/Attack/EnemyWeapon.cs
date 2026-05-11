using Enemy;
using Attack;
using UnityEngine;

namespace Enemy
{
    public class EnemyWeapon : Sword
    {
        [SerializeField] private EnemyBehavior enemy;
        protected override void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);
        }

        protected override void OnAttackEnd()
        {
            base.OnAttackEnd();
            enemy.PerformRetreat();
        }
    }
}