using Attack;
using GameManagement;
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

            if (Input.GetKeyDown(InputManager.CastPerkSlot1)) CastPerkAtSlot(0);
            if (Input.GetKeyDown(InputManager.CastPerkSlot2)) CastPerkAtSlot(1);
            if (Input.GetKeyDown(InputManager.CastPerkSlot3)) CastPerkAtSlot(2);
            if (Input.GetKeyDown(InputManager.CastPerkSlot4)) CastPerkAtSlot(3);

        }

        public void SetComponentData(PlayerStats stats)
        {
            if (gameObject.TryGetComponent<Attacker>(out var outAttacker) && gameObject.TryGetComponent<EntityWithHealth>(out var outDefender))
            {
                outAttacker.SetData(stats.atkDamage, stats.strength);
                outDefender.SetData(stats.defense, stats.maxHealth);
            }
        }
        private void CastPerkAtSlot(int perkIndex)
        {
            perkManager.CastPerk(perkIndex);
        }
    }
}
