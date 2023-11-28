using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class PlayerMovement : MonoBehaviour
{
    private CustomInput input = null;
    private Vector2 moveVector = Vector2.zero;
    private Rigidbody2D Rigidbody = null;
    public float moveSpeed = 10f;
    private Vector2 screenBounds;
    private float playerWidth;
    private float playerHeight;
    public Animator animator;
    private string isMovingBoolName = "isMoving";
    private void Awake()
    {
        input = new CustomInput();
        Rigidbody = GetComponent<Rigidbody2D>();
        //TODO: TP2 - Fix - Possible null reference (camera.main)
        if (Camera.main != null) { screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z)); }
        playerWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        playerHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    private void OnEnable()
    {
        input.Enable();
        input.Player.Movement.performed += OnMovementPerformed;
        input.Player.Movement.canceled += OnMovementCancelled;
    }

    private void OnDisable()
    {
        input.Disable();
        input.Player.Movement.performed -= OnMovementPerformed;
        input.Player.Movement.canceled -= OnMovementCancelled;
    }

    private void FixedUpdate()
    {
        Rigidbody.velocity = moveVector * moveSpeed;
    }

    private void LateUpdate()
    {
        Vector3 ViewPosition = transform.position;
        ViewPosition.x = Mathf.Clamp(ViewPosition.x, screenBounds.x * -1 + playerWidth, screenBounds.x - playerWidth);
        ViewPosition.y = Mathf.Clamp(ViewPosition.y, screenBounds.y * -1 + playerHeight, screenBounds.y - playerHeight);
        transform.position = ViewPosition;
    }

    //TODO: TP2 - Move all input reads to specific class
    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        //TODO: TP2 - Fix - Hardcoded value/s
        animator.SetBool(isMovingBoolName, true);
        moveVector = value.ReadValue<Vector2>();
    }

    private void OnMovementCancelled(InputAction.CallbackContext value)
    {
        //TODO: TP2 - Fix - Hardcoded value/s
        animator.SetBool(isMovingBoolName, false);
        moveVector = Vector2.zero;
    }

    public void Update()
    {
        animator.SetFloat("Horizontal", moveVector.x);
        animator.SetFloat("Vertical", moveVector.y);
    }
}
