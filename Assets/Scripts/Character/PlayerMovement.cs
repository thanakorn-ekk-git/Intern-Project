using UnityEngine;

namespace Character {
    public class PlayerMovement : CharacterMovement {
        private Camera playerCam;

        [Range(0.1f, 50f), SerializeField] protected float jumpForce = 5f;
        [Range(0.1f, 50f), SerializeField] protected float jumpAcc = 2.5f;
        private float jumpRemainForce = 0f;

        protected override void Awake() {
            base.Awake();
            playerCam = Camera.main;
        }

        protected override void Update() {
            PlayerInput();
            base.Update();
        }

        private void PlayerInput() {
            var kbMove = InputManager.KeyBoardMove;

            float x = kbMove.x;
            float z = kbMove.y;

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

            if (Input.GetKeyDown(InputManager.Sprint)) 
            {
                moveSpeedMultiplier = 2f;
            }
            else if (Input.GetKeyUp(InputManager.Sprint)) 
            { 
                moveSpeedMultiplier = 1f;
            }

            if (jumpRemainForce <= 1f) 
            {
                if (Input.GetKeyDown(InputManager.Jump)) 
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
