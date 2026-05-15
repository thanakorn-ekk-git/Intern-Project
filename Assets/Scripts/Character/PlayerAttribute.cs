using Attack;
using UnityEngine;

namespace Character
{
    public class PlayerAttribute : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private Attacker attacker;

        public int MaxHealth => maxHealth;
        [SerializeField] private int maxHealth;
        public int Mana => mana;
        [SerializeField] private int mana;
        public int AtkDamage => atkDamage;
        [SerializeField] private int atkDamage;
        public int Strength => strength;
        [SerializeField] private int strength;
        public int Dexterity => dexterity;
        [SerializeField] private int dexterity;
        public int Defense => defense;
        [SerializeField] private int defense;
        public int Intelligence => intelligence;
        [SerializeField] private int intelligence;

        public void ApplyPlayerData(Data.PlayerData.PlayerStats stats)
        {
            maxHealth = stats.Health;
            mana = stats.Mana;
            atkDamage = stats.AtkDamage;
            strength = stats.Strength;
            dexterity = stats.Dexterity;
            defense = stats.Defence;
            intelligence = stats.Intelligence;

            if (player.TryGetComponent<EntityWithHealth>(out var playerHealth))
            {
                playerHealth.health = stats.Health;
            }
            if(player.TryGetComponent<DamageInfo>(out var dmgInfo))
            {
                //dmgInfo.
            }
        }
    }
}
