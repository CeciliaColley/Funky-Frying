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

    private SliceInputActions sliceInput;

    private void Awake()
    {
        sliceInput = new SliceInputActions();
        sliceInput.SliceMap.AddCallbacks(this);
    }

    private void OnEnable()
    {
        sliceInput.Enable();
    }

    private void OnDisable()
    {
        sliceInput.Disable();
    }

    void Start()
    {
        StartingPoint = transform.position;
    }

    void Update()
    {
        // TODO: TP2 - Fix - Clean code
        if (Chopped)
        {
            transform.position = transform.position + Vector3.down * SliceSpeed * Time.deltaTime;
            if (transform.position.y < StartingPoint.y)
            {
                transform.position = StartingPoint;
                Chopped = false;
            }
        }
    }

    public void OnSliceAction(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
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
            }

            transform.position = new Vector3(0, 0, 0);
            Chopped = true;
        }
        else if (context.canceled)
        {
            transform.position = StartingPoint;
            Chopped = false;
        }
    }
}