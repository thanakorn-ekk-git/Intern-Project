using UnityEngine;
using Character;

namespace Attack
{
    public class DamageInfo
    {
        [SerializeField] private GameObject self;
        public int Damage => damage;
        [SerializeField] private int damage;
        public Attacker Attacker => attacker;
        [SerializeField] private Attacker attacker;

        public void SetAttribute(int newDamage, Attacker attacker)
        {
            if(self.TryGetComponent<PlayerAttribute>(out var playerAttribute))
            {
                damage = newDamage + playerAttribute.Strength;
            }
        }

        public DamageInfo(int damage, Attacker attacker )
        {
            this.damage = damage;
            this.attacker = attacker;
        }
    }
}