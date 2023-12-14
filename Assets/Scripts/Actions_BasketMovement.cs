using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Actions_BasketMovement : MonoBehaviour
{
    [SerializeField] private InputBasketMovement basketMovement;
    [SerializeField] private BasketBehaviour basket;
    [SerializeField] private float basketSpeed = 5.0f;
    [SerializeField] private float noMovement = 0f;

    private void Awake()
    {
        // Initialize basketMovement input actions
        basketMovement = new InputBasketMovement();
    }

    private void Start()
    {
        // Find the BasketBehaviour in the scene
        basket = FindObjectOfType<BasketBehaviour>();
    }

    private void OnEnable()
    {
        // Enable input actions and attach event handlers
        if (basketMovement != null)
        {
            basketMovement.Enable();
            basketMovement.BasketMovementActionMap.MoveRight.performed += MoveBasket;
            basketMovement.BasketMovementActionMap.MoveLeft.performed += MoveBasket;
        }
    }

    private void OnDisable()
    {
        // Disable input actions and detach event handlers
        if (basketMovement != null )
        {
            basketMovement.Disable();
            basketMovement.BasketMovementActionMap.MoveRight.performed -= MoveBasket;
            basketMovement.BasketMovementActionMap.MoveLeft.performed -= MoveBasket;
        }
    }

    private void MoveBasket(InputAction.CallbackContext value)
    {
        // Start the coroutine to move the basket based on input
        StartCoroutine(Move(value));
    }

    private IEnumerator Move(InputAction.CallbackContext value)
    {
        int direction = 0;

        while (value.ReadValue<float>() != noMovement)
        {
            // Get the control path and determine the direction
            string controlPath = value.control?.path;
            int lastIndex = controlPath.LastIndexOf('/');

            if (controlPath != null)
            {
                if ( controlPath.Equals("/Keyboard/rightArrow") || controlPath.Substring(lastIndex + 1).Equals("right") )
                {
                    direction = 1;
                }
                else if (controlPath.Equals("/Keyboard/leftArrow") || controlPath.Substring(lastIndex + 1).Equals("left"))
                {
                    direction = -1;
                }
            }

            // Move the basket based on the determined direction
            float movement = direction * basketSpeed * Time.deltaTime;
            if (basket != null) { basket.transform.Translate(new Vector3(movement, 0.0f, 0.0f)); }
            yield return null;
        }
    }
}
