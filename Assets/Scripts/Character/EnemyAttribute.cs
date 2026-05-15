using Attack;
using UnityEngine;

namespace Character
{
    public enum EnemyType
    {
        Mini,Normal, MiniBoss, Boss
    }
    public class EnemyAttribute : MonoBehaviour
    {
        [SerializeField] private GameObject enemySelf;
        [SerializeField] private Attacker attacker;

        [SerializeField] private string displayName = "Enemy";
        [SerializeField] private string id = "0000";
        [SerializeField] private EnemyType enemyType;

        public int MaxHealth => maxHealth;
        [SerializeField] private int maxHealth;
        public int AtkDamage => atkDamage;
        [SerializeField] private int atkDamage;
        public int Defense => defense;
        [SerializeField] private int defense;
        public float MoveSpeed => moveSpeed;
        [SerializeField] private float moveSpeed;
        public float AttackSpeed => attackSpeed;
        [SerializeField] private float attackSpeed;
        public float AttackRange => attackRange;
        [SerializeField] private float attackRange;
        public float DetectionRange => detectionRange;
        [SerializeField] private float detectionRange;
        public float KnockbackResistance => knockbackResistance;
        [SerializeField] private float knockbackResistance;

        public float ExpDrop => expDrop;
        [SerializeField] private float expDrop;
        public float GoldDrop => goldDrop;
        [SerializeField] private float goldDrop;

    }
}