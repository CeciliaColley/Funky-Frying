using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class RatTrapMovementScript : MonoBehaviour
{
    [SerializeField] private RatTrapInputAsset ratTrapMovement;
    [SerializeField] private RatTrapBehaviour ratTrap;
    [SerializeField] private float ratTrapSpeed = 5.0f;
    [SerializeField] private float noMovement = 0f;
    [SerializeField] private int still = 0;
    [SerializeField] private int up = 1;
    [SerializeField] private int down = -1;

    private void Awake()
    {
        // Initialize ratTrapMovement and find RatTrapBehaviour in the scene
        ratTrapMovement = new RatTrapInputAsset();
        ratTrap = FindObjectOfType<RatTrapBehaviour>();
    }

    private void OnEnable()
    {
        // Enable input actions and attach event handlers
        if (ratTrapMovement != null)
        {
            ratTrapMovement.Enable();
            ratTrapMovement.RatTrapActions.MoveUp.performed += MoveRatTrap;
            ratTrapMovement.RatTrapActions.MoveDown.performed += MoveRatTrap;
        }
    }

    private void OnDisable()
    {
        // Disable input actions and detach event handlers
        if (ratTrapMovement != null)
        {
            ratTrapMovement.Disable();
            ratTrapMovement.RatTrapActions.MoveUp.performed -= MoveRatTrap;
            ratTrapMovement.RatTrapActions.MoveDown.performed -= MoveRatTrap;
        }
    }

    private void MoveRatTrap(InputAction.CallbackContext value)
    {
        // Start the coroutine to move the RatTrap based on input
        StartCoroutine(Move(value));
    }

    private IEnumerator Move(InputAction.CallbackContext value)
    {
        int direction = still;

        while (value.ReadValue<float>() != noMovement)
        {
            // Check if the controlPath corresponds to up or down input
            string controlPath = value.control.path;
            int lastIndex = controlPath.LastIndexOf('/');

            if (controlPath != null)
            {
                if (controlPath == "/Keyboard/upArrow" || controlPath[(lastIndex + 1)..] == "up")
                {
                    direction = up;
                }
                else if (controlPath == "/Keyboard/downArrow" || controlPath[(lastIndex + 1)..] == "down")
                {
                    direction = down;
                }
            }
            
            // Move the RatTrap based on the determined direction
            float movement = direction * ratTrapSpeed * Time.deltaTime;
            if (ratTrap != null) { ratTrap.transform.position += new Vector3(0f, movement, 0f); }
            yield return null;
        }
    }
}
