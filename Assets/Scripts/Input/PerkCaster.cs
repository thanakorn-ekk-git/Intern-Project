using Player;
using System.Collections.Generic;
using UnityEngine;

namespace Perk
{
    [RequireComponent(typeof(PlayerController))]
    public class PerkCaster : MonoBehaviour
    {
        [SerializeField] private PlayerController player;
        private Dictionary<int, PerkGameplay> perkCasterSlot;

        private void Update()
        {
            if (Input.GetKeyDown(InputManager.CastPerkSlot1)) CastPerkAtSlot(1);
            if (Input.GetKeyDown(InputManager.CastPerkSlot2)) CastPerkAtSlot(2);
            if (Input.GetKeyDown(InputManager.CastPerkSlot3)) CastPerkAtSlot(3);
            if (Input.GetKeyDown(InputManager.CastPerkSlot4)) CastPerkAtSlot(4);
        }

        private void CastPerkAtSlot(int perkIndex)
        {

        }
    }
}