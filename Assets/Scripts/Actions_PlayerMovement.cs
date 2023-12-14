using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class Actions_PlayerMovement : MonoBehaviour
{
    [SerializeField] private CustomInput input = null;
    [SerializeField] private Rigidbody2D playerRigidbody = null;
    [SerializeField] private Animator animator;
    [SerializeField] private Vector2 moveVector = Vector2.zero;
    [SerializeField] private float moveSpeed = 10.0f;
    [SerializeField] private string isMovingBoolName = "isMoving";
    [SerializeField] private string yParameter = "Vertical";
    [SerializeField] private string xParameter = "Horizontal";
    private void Awake()
    {
        // Initialize input and player rigidbody
        input = new CustomInput();
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        // Enable input and attach event handlers for movement
        if (input != null)
        {
            input.Enable();
            input.Player.Movement.performed += OnMovementPerformed;
            input.Player.Movement.canceled += OnMovementCancelled;
        }
    }

    private void OnDisable()
    {
        // Disable input and detach event handlers for movement
        if (input != null)
        {
            input.Disable();
            input.Player.Movement.performed -= OnMovementPerformed;
            input.Player.Movement.canceled -= OnMovementCancelled;
        }
    }

    private void FixedUpdate()
    {
        // Update the player's velocity in FixedUpdate based on the moveVector and moveSpeed
        if (playerRigidbody != null) { playerRigidbody.velocity = moveVector * moveSpeed; }
    }

    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        // Handle movement input when performed
        if (animator != null)
        {
            animator.SetBool(isMovingBoolName, true);
            moveVector = value.ReadValue<Vector2>();
        }
    }

    private void OnMovementCancelled(InputAction.CallbackContext value)
    {
        // Handle movement input when canceled
        if (animator != null)
        {
            animator.SetBool(isMovingBoolName, false);
            moveVector = Vector2.zero;
        }
    }

    private void Update()
    {
        // Update animator parameters based on the moveVector
        if (animator != null)
        {
            animator.SetFloat(yParameter, moveVector.y);
            animator.SetFloat(xParameter, moveVector.x);
        }
    }
}
