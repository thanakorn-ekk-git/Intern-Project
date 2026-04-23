using System;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    bool isPlayer = false;
    private Camera playerCam;
    private CharacterController charController;
    public Collider groundChecker;

    [Header("Character Movement Settings")]
    public float moveSpeed = 5f;
    public float moveSpeedMultiplier = 1f;
    public float gravityForce = 9.81f;
    public float jumpForce = 5f;
    private Vector3 velocity;
    private float vertVelocity;
    private Vector3 curInputDirection;

    public LayerMask groundLayer;

    private void Awake()
    {
        if (gameObject.tag == "Player")
        {
            isPlayer = true;
            playerCam = Camera.main;
        }
    }
    void Start()
    {
        charController = GetComponent<CharacterController>();
        
    }

    void Update()
    {
        if(isPlayer)
        {
            PlayerInput();
        }
        ApplyGravity();
        ApplyMovement();

    }
    public void Move(Vector3 direction)
    {
        curInputDirection = direction;
    }
    private void ApplyMovement()
    {
        Vector3 horizonMove = curInputDirection * moveSpeed * moveSpeedMultiplier;

        if (curInputDirection.magnitude >= 0.1f)
        {
            Vector3 flatDirection = new Vector3(curInputDirection.x, 0f, curInputDirection.z);
            Quaternion targetRotation = Quaternion.LookRotation(flatDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }

        Vector3 finalVelocity = new Vector3(horizonMove.x, vertVelocity, horizonMove.z);
        charController.Move(finalVelocity * Time.deltaTime);

        if (!isPlayer)
            curInputDirection = Vector3.zero;
        
    }

    private void ApplyGravity()
    {
        if(charController.isGrounded)
        {
            vertVelocity = -1f;
        }
        else
        {
            vertVelocity -= gravityForce * Time.deltaTime;
        }
    }
    private void PlayerInput()
    {
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
            Move(Vector3.zero);

        if(Input.GetKeyDown(KeyCode.LeftShift))
            moveSpeedMultiplier = 2f;
        else if(Input.GetKeyUp(KeyCode.LeftShift))
            moveSpeedMultiplier = 1f;

        if (Input.GetKeyDown(KeyCode.Space))
            charController.Move(Vector3.up * jumpForce * Time.deltaTime);

    }
}
