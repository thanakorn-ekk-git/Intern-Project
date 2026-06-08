using Attack;
using Perk;
using UnityEngine;
using static Data.PlayerGameData;

namespace Player
{
    [RequireComponent(typeof(Attacker))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Attacker attacker;
        public PerkManager PerkManager => perkManager;
        [SerializeField] private PerkManager perkManager;

        public string PerkNameToUnlock => perkNameToUnlock;
        [SerializeField] private string perkNameToUnlock;

        private void Start()
        {
            attacker = GetComponent<Attacker>();
            perkManager = new PerkManager(this);
        }

        void Update()
        {
            if (InputManager.Attack)
            {
                attacker.Attack();
            }
        }

        public void SetComponentData(PlayerStats stats)
        {
            if (gameObject.TryGetComponent<Attacker>(out var outAttacker) && gameObject.TryGetComponent<EntityWithHealth>(out var outDefender))
            {
                outAttacker.SetData(stats.atkDamage, stats.strength);
                outDefender.SetData(stats.defense, stats.maxHealth);
            }
        }
    }
}
