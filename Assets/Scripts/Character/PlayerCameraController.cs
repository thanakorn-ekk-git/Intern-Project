using UnityEngine;
using UnityEngine.InputSystem;

namespace Character { 
    public class PlayerCameraController : MonoBehaviour
    {
        public Transform playerPos;
        public float mouseSensitivity = 100f;

        float xRotation = 0f;
        float yRotation = 0f;
        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        void LateUpdate()
        {
            if(playerPos == null) 
                return;

            transform.position = playerPos.position;

            float mouseX = InputManager.MouseMove.x * Time.deltaTime;
            float mouseY = InputManager.MouseMove.y * Time.deltaTime;

            yRotation += mouseX;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -80f, 80f);

            transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
        }
    }
}