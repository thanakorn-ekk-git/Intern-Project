using Character;
using System;
using System.Net.NetworkInformation;
using UnityEngine;

namespace Attack
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerAttackSystem : MonoBehaviour
    {

        public GameObject playerSword;

        private bool isAttacking;

        private CharacterController charController;
        private Vector3 impactVector = Vector3.zero;

        [Range(0.1f, 50f), SerializeField] public float dashForce = 10f;
        [Range(0.1f, 10f), SerializeField] public float drag = 5f;

        private void Awake()
        {
            charController = GetComponent<CharacterController>();
        }
        void Start()
        {

        }
        void Update()
        {
            if (Input.GetKeyDown(InputManager.Attack))
            {
                Attack();
            }
            AttackImpact();
        }

        private void AttackImpact()
        {
            if (impactVector.magnitude > 0.2f)
            {
                impactVector = Vector3.Lerp(impactVector, Vector3.zero, drag * Time.deltaTime);
            }
            else
            {
                impactVector = Vector3.zero;
            }
            charController.Move(impactVector * Time.deltaTime);
        }

        public void Attack()
        {
            impactVector = transform.forward * dashForce;
            print("Attack!");
            playerSword.GetComponent<Animator>().SetTrigger("AttackTrig");
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
