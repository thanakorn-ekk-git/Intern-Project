using Character;
using UnityEngine;

namespace Attack
{
    public class EntityWithHealth : MonoBehaviour
    {
        [SerializeField] private GameObject self;
        public int health = 100;
        public void TakeDamage(DamageInfo dmgInfo)
        {
            if(self.TryGetComponent<PlayerAttribute>(out var player))
            {
                int damageCalculated = dmgInfo.Damage - player.Defense;
                
                health -= (dmgInfo.Damage - player.Defense);
            }
            else if (self.TryGetComponent<EnemyAttribute>(out var enemy))
            {
                health -= dmgInfo.Damage;
            }
            
            if (health <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}