using UnityEngine;
using Attack;

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
                StartCoroutine(attacker.AttackImpactCoroutine(2.0f));
            }
        }
    }
}
