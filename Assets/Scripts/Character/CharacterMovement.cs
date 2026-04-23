using System;
using UnityEngine;

namespace Character {
    [RequireComponent(typeof(CharacterController))]
    public abstract class CharacterMovement : MonoBehaviour {
        protected CharacterController charController;

        [Header("Character Movement Settings")]
        [Range(0.1f, 50f), SerializeField] protected float moveSpeed = 5f;
        [Range(0.1f, 50f), SerializeField] protected float moveSpeedMultiplier = 1f;
        [Range(0.1f, 50f), SerializeField] private float gravityMult = 1f;
        private float gravityVelocity;
        private float vertVelocity;
        private Vector3 curInputDirection;

        protected virtual void Awake() {
            charController = GetComponent<CharacterController>();
        }

        protected virtual void Update() {
            ApplyGravity();
            ApplyMovement();
        }

        public void Move(Vector3 direction) {
            curInputDirection = direction;
        }

        protected void SetVertVelocity(float velocity) => vertVelocity = velocity;

        protected virtual void ApplyMovement() {
            Vector3 horizonMove = curInputDirection * moveSpeed * moveSpeedMultiplier;

            if (curInputDirection.magnitude >= 0.1f) {
                Vector3 flatDirection = new Vector3(curInputDirection.x, 0f, curInputDirection.z);
                Quaternion targetRotation = Quaternion.LookRotation(flatDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
            }

            Vector3 finalVelocity = new Vector3(horizonMove.x, gravityVelocity + vertVelocity, horizonMove.z);
            charController.Move(finalVelocity * Time.deltaTime);
        }

        protected void ResetInputDirection() => curInputDirection = Vector3.zero;

        private void ApplyGravity() {
            const float KeepGroundValue = -1f;
            if (charController.isGrounded) {
                gravityVelocity = KeepGroundValue;
            } else {
                gravityVelocity -= (-Physics.gravity.y * gravityMult) * Time.deltaTime;
            }
        }
        
    }
}