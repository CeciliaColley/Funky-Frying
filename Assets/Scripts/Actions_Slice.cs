using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class Actions_Slice : MonoBehaviour, SliceInputActions.ISliceMapActions
{
    public enum InputOptions { up, down, left, right }
    public InputOptions ArrowPressed; // Referenced by ChopLogic and TutorialHitZone

    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private SliceInputActions sliceInput;
    [SerializeField] private Vector3 startingPoint;
    [SerializeField] private bool Chopped = false;
    [SerializeField] private float sliceSpeed;

    private void Awake()
    {
        // Initialize the SliceInputActions and add callbacks
        sliceInput = new SliceInputActions();
        sliceInput.SliceMap.AddCallbacks(this);
    }

    private void OnEnable()
    {
        // Enable the SliceInputActions
        if (sliceInput != null) { sliceInput.Enable(); }
    }

    private void OnDisable()
    {
        // Disable the SliceInputActions
        if (sliceInput != null) { sliceInput.Disable(); }
    }

    private void Start()
    {
        // Set the starting point for reference
        startingPoint = transform.position;
    }

    private IEnumerator ChopAnimation()
    {
        // Perform chop animation by moving the object down
        while (transform.position.y > startingPoint.y)
        {
            transform.position += sliceSpeed * Time.deltaTime * Vector3.down;
            yield return null;
        }
        // Reset the position to the starting point
        transform.position = startingPoint;
    }

    public void OnSliceAction(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            // Determine the arrow direction based on the control path
            switch (context.control.path)
            {
                case "/Keyboard/upArrow":
                    ArrowPressed = InputOptions.up;
                    break;
                case "/Keyboard/downArrow":
                    ArrowPressed = InputOptions.down;
                    break;
                case "/Keyboard/leftArrow":
                    ArrowPressed = InputOptions.left;
                    break;
                case "/Keyboard/rightArrow":
                    ArrowPressed = InputOptions.right;
                    break;
                case "/Gamepad/dpad/up":
                case "/XInputControllerWindows/dpad/up":
                    ArrowPressed = InputOptions.up;
                    break;
                case "/Gamepad/dpad/down":
                case "/XInputControllerWindows/dpad/down":
                    ArrowPressed = InputOptions.down;
                    break;
                case "/Gamepad/dpad/left":
                case "/XInputControllerWindows/dpad/left":
                    ArrowPressed = InputOptions.left;
                    break;
                case "/Gamepad/dpad/right":
                case "/XInputControllerWindows/dpad/right":
                    ArrowPressed = InputOptions.right;
                    break;
                default:
                    break;
            }
            // Reset the position and start the chop animation
            transform.position = new Vector3(0, 0, 0);
            StartCoroutine(ChopAnimation());
        }
        
        else if (context.canceled)
        {
            // Reset the position when slice action is canceled
            transform.position = startingPoint;
        }
    }
}