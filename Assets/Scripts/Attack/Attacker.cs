using System.Collections;
using UnityEngine;

namespace Attack
{
    [RequireComponent(typeof(CharacterController))]
    public class Attacker : MonoBehaviour
    {
        [SerializeField] private Animator weaponAnimator;
        public GameObject weapon;

        [SerializeField] private CharacterController charController;
        private Vector3 impactVector = Vector3.zero;

        [Range(0.1f, 50f), SerializeField] private float dashForce = 10f;
        [Range(0.1f, 10f), SerializeField] private float drag = 5f;


        private void Awake()
        {
            charController = GetComponent<CharacterController>();
        }
        void Update()
        {
            if (InputManager.Attack)
            {
                Attack();
                StartCoroutine(AttackImpactCoroutine(2.0f));
            }
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

        IEnumerator AttackImpactCoroutine(float duration)
        {
            AttackImpact();
            yield return new WaitForSeconds(duration);
        }


        public void Attack()
        {
            impactVector = transform.forward * dashForce;
            weapon.GetComponent<Animator>().SetTrigger("AttackTrig");
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
