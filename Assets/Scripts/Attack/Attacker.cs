using Character;
using System.Collections;
using UnityEngine;

namespace Attack
{
    [RequireComponent(typeof(CharacterController))]
    public class Attacker : MonoBehaviour, IAttackable
    {
        [SerializeField] private int atkDamage;
        [SerializeField] private int strength;
        public int AtkDamage => atkDamage;
        public int Strength => strength;

        [SerializeField] private Animator weaponAnimator;

        [SerializeField] private CharacterController charController;
        private Vector3 impactVector = Vector3.zero;

        [Range(0.1f, 50f), SerializeField] private float dashForce = 10f;
        [Range(0.1f, 10f), SerializeField] private float drag = 5f;

        private void Awake()
        {
            charController = GetComponent<CharacterController>();
        }

        private void AttackImpact()
        {
            impactVector = Vector3.Lerp(impactVector, Vector3.zero, drag * Time.deltaTime);
            if (impactVector.magnitude <= 0.2f)
            {
                impactVector = Vector3.zero;
            }
            charController.Move(impactVector * Time.deltaTime);
        }

        public IEnumerator AttackImpactCoroutine(float duration)
        {
            AttackImpact();
            yield return new WaitForSeconds(duration);
        }

        public void Attack()
        {
            StartCoroutine(AttackImpactCoroutine(2.0f));

            impactVector = transform.forward * dashForce;

            const string ANIMATION_ATTACK_TRIGGER = "AttackTrig";
            weaponAnimator.SetTrigger(ANIMATION_ATTACK_TRIGGER);
        }

        public void SetData(int damage, int strength)
        {
            atkDamage = damage;
            this.strength = strength;
        }

        private void HitImpact()
        {
            // TODO : add shake effect to player
        }
        private void CameraChake()
        {
            // TODO : add shake effect to camera
        }
    }
}