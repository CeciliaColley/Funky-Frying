using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class SliceActions : MonoBehaviour, SliceInputActions.ISliceMapActions
{
    [SerializeField] public Rigidbody2D Rigidbody;
    [SerializeField] private Vector3 StartingPoint;
    [SerializeField] private bool Chopped = false;
    [SerializeField] public float SliceSpeed;
    public enum InputOptions
    {
        up,
        down,
        left,
        right
    }
    [SerializeField] public InputOptions ArrowPressed;

    // New Input System action for slicing
    private SliceInputActions sliceInput;

    private void Awake()
    {
        // Initialize the SliceInputActions instance
        sliceInput = new SliceInputActions();

        // Add this script as a callback to the input actions
        sliceInput.SliceMap.AddCallbacks(this);
    }

    private void OnEnable()
    {
        // Enable the input actions when the script is enabled
        sliceInput.Enable();
    }

    private void OnDisable()
    {
        // Disable the input actions when the script is disabled
        sliceInput.Disable();
    }

    void Start()
    {
        // Store the initial position of the GameObject
        StartingPoint = transform.position;
    }

    void Update()
    {
        // TODO: TP2 - Fix - Clean code
        if (Chopped)
        {
            // Move the GameObject downward when Chopped is true
            transform.position = transform.position + Vector3.down * SliceSpeed * Time.deltaTime;

            // Reset position if it goes below the starting point
            if (transform.position.y < StartingPoint.y)
            {
                transform.position = StartingPoint;
                Chopped = false;
            }
        }
    }

    public void OnSliceAction(InputAction.CallbackContext context)
    {
        // Perform slice logic when the action is triggered (performed)
        if (context.performed)
        {
            
            // Determine which arrow key was pressed based on the control path
            switch (context.control.path)
            {
                case "/Keyboard/upArrow":
                    ArrowPressed = InputOptions.up;
                    Debug.Log("Arrow Pressed: " + ArrowPressed);
                    break;
                case "/Keyboard/downArrow":
                    ArrowPressed = InputOptions.down;
                    Debug.Log("Arrow Pressed: " + ArrowPressed);
                    break;
                case "/Keyboard/leftArrow":
                    ArrowPressed = InputOptions.left;
                    Debug.Log("Arrow Pressed: " + ArrowPressed);
                    break;
                case "/Keyboard/rightArrow":
                    ArrowPressed = InputOptions.right;
                    Debug.Log("Arrow Pressed: " + ArrowPressed);
                    break;
            }

            // Move the GameObject to a new position
            transform.position = new Vector3(0, 0, 0);

            // Set Chopped to true, triggering the Update method to move the GameObject downward
            Chopped = true;
        }
        // Reset position when the action is released (canceled)
        else if (context.canceled)
        {
            transform.position = StartingPoint;
            Chopped = false;
        }
    }
}