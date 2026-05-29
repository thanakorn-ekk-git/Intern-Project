using Attack;
using UnityEngine;
using static Data.PlayerGameData;

namespace Player
{
    [RequireComponent(typeof(Attacker))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Attacker attacker;

        private void Start()
        {
            attacker = GetComponent<Attacker>();
        }

        void Update()
        {
            if (InputManager.Attack)
            {
                attacker.Attack();
            }
        }
        public void Load()
        {
        }

        public static void SetComponentData(PlayerStats stats)
        {
            if (gameObject.TryGetComponent<Attacker>(out var outAttacker) && gameObject.TryGetComponent<EntityWithHealth>(out var outDefender))
            {
                outAttacker.SetData(stats.atkDamage, stats.strength);
                outDefender.SetData(stats.defense, stats.maxHealth);
            }
        }
    }
}
