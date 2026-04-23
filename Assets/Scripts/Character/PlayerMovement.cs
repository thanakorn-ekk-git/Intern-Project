using UnityEngine;

namespace Character {
    public class PlayerMovement : CharacterMovement {
        bool isPlayer = false;
        private Camera playerCam;

        [Range(0.1f, 50f), SerializeField] protected float jumpForce = 5f;
        [Range(0.1f, 50f), SerializeField] protected float jumpAcc = 2.5f;
        private float jumpRemainForce = 0f;

        protected override void Awake() {
            base.Awake();
            isPlayer = true;
            playerCam = Camera.main;
        }

        protected override void Update() {
            PlayerInput();
            base.Update();
        }

        private void PlayerInput() {
            float x = Input.GetAxisRaw("Horizontal");
            float z = Input.GetAxisRaw("Vertical");

            Vector3 direction = new Vector3(x, 0f, z);

            if (direction.magnitude >= 0.1f) 
            {
                direction.Normalize();

                Vector3 camForward = playerCam.transform.forward;
                Vector3 camRight = playerCam.transform.right;

                camForward.y = 0f;
                camRight.y = 0f;
                camForward.Normalize();
                camRight.Normalize();

                Vector3 moveDirection = (camForward * direction.z) + (camRight * direction.x);
                moveDirection.Normalize();

                Move(moveDirection);
            }
            else 
            {
                Move(Vector3.zero);
            }

            if (Input.GetKeyDown(KeyCode.LeftShift)) 
            {
                moveSpeedMultiplier = 2f;
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift)) 
            { 
                moveSpeedMultiplier = 1f;
            }

            if (jumpRemainForce <= 1f) 
            {
                if (Input.GetKeyDown(KeyCode.Space)) 
                {
                    jumpRemainForce = jumpForce;
                }
            }
            var up = Mathf.Min(jumpAcc, jumpRemainForce);
            jumpRemainForce -= up;
            SetVertVelocity(up);
        }
    }
}
