using Attack;
using System;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

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

        public static PlayerController GetPlayer()
        {
            var tmpPlayer = GameObject.FindFirstObjectByType<PlayerController>();
            return tmpPlayer;
        }
    }
}
