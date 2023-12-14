using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions_PantryCheats : MonoBehaviour
{
    [SerializeField] private List<PantryIngredientBehaviour> activeIngredients = new();
    [SerializeField] private List<RatBehaviour> activeRats = new();
    [SerializeField] private CheatControls cheats;
    [SerializeField] private PantryGameRules pantryLogic;
    [SerializeField] private LossPoint lossPoint;
    [SerializeField] private BasketBehaviour basket;
    [SerializeField] private float halfScreenWidth;
    [SerializeField] private float halfScreenHeight;
    [SerializeField] private bool slow = false;
    [SerializeField] private bool catchAll = false;
    [SerializeField] private int slowDownSpeed = 2;
    [SerializeField] private int transformSign = -1;
    [SerializeField] private int winningIngredients = 15;
    [SerializeField] private int winningEscapedRats = 0;

    private void Awake()
    {
        // Initialize variables and find necessary managers in the scene
        pantryLogic = FindObjectOfType<PantryGameRules>();
        lossPoint = FindObjectOfType<LossPoint>();
        basket = FindObjectOfType<BasketBehaviour>();
        if (Camera.main != null)
        {
            halfScreenWidth = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
            halfScreenHeight = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
        }
        cheats = new CheatControls();
    }

    private void OnEnable()
    {
        // Enable cheats and attach event handlers
        if (cheats != null)
        {
            cheats.Enable();
            cheats.CustomCheatControls.Win.performed += ctx => WinAction();
            cheats.CustomCheatControls.SlowDown.performed += ctx => SlowDownAction();
            cheats.CustomCheatControls.ChangePosition.performed += ctx => CatchAll();
        }
    }

    private void OnDisable()
    {
        // Disable cheats and detach event handlers
        if (cheats != null )
        {
            cheats.Disable();
            cheats.CustomCheatControls.Win.performed -= ctx => WinAction();
            cheats.CustomCheatControls.SlowDown.performed -= ctx => SlowDownAction();
            cheats.CustomCheatControls.ChangePosition.performed -= ctx => CatchAll();
        }
    }

    private void WinAction()
    {
        // Set game state to winning conditions so you win immediately
        if (pantryLogic != null)
        {
            pantryLogic.ingredientsSaved = winningIngredients;
            pantryLogic.ratsEscaped = winningEscapedRats;
        }
    }

    private void SlowDownAction()
    {
        // Toggle slow motion and start or stop the SlowDown coroutine
        slow = !slow;
        if (slow) { StartCoroutine(SlowDown()); }
        if (!slow) { StopCoroutine(SlowDown()); }
    }

    private void CatchAll()
    {
        // Toggle catch-all mode and disable the collider that checks for missed objects, while enabling the collider that checks for good objects.
        catchAll = !catchAll;
        if (basket != null && lossPoint != null)
        {
            if (catchAll)
            {
                basket.GetComponent<Collider2D>().enabled = false;
                lossPoint.GetComponent<PolygonCollider2D>().enabled = false;
                StartCoroutine(CatchEverything());
            }
            if (!catchAll)
            {
                basket.GetComponent<Collider2D>().enabled = true;
                lossPoint.GetComponent<PolygonCollider2D>().enabled = true;
                StopCoroutine(CatchEverything());
            }
        }
    }

    public void AddIngredientToList(PantryIngredientBehaviour ingredient) // Referenced by PantryIngredientBehaviour
    {
        // Add ingredient to the activeIngredients list
        if (activeIngredients != null) { activeIngredients.Add(ingredient); }
    }

    public void RemoveIngredientFromList(PantryIngredientBehaviour ingredient) // Referenced by PantryIngredientBehaviour
    {
        // Remove ingredient from the activeIngredients list
        if (activeIngredients != null) { activeIngredients.Remove(ingredient); }
    }

    public void AddRatToList(RatBehaviour rat) //Referenced by RatBehaviour
    {
        // Add rat to the activeRats list
        if (activeRats != null) { activeRats.Add(rat); }
    }

    public void RemoveRatFromList(RatBehaviour rat) //Referenced by RatBehaviour
    {
        // Remove rat from the activeRats list
        if (activeRats != null) { activeRats.Remove(rat); }
    }

    private IEnumerator SlowDown()
    {
        // Slow down ingredients and rats while slow motion is active
        if (activeIngredients != null && activeRats != null)
        {
            while (slow)
            {
                foreach (PantryIngredientBehaviour ingredient in activeIngredients)
                {
                    ingredient.moveSpeed = slowDownSpeed;
                }
                foreach (RatBehaviour rat in activeRats)
                {
                    rat.moveSpeed = slowDownSpeed;
                }

                yield return null;
            }
        }
    }

    private IEnumerator CatchEverything()
    {
        // Catch everything during catch-all mode
        if (activeIngredients != null && activeRats != null)
        {
            while (catchAll)
            {
                foreach (PantryIngredientBehaviour ingredient in activeIngredients)
                {
                    if (ingredient != null && ingredient.isGood && ingredient.transform.position.y <= halfScreenHeight * transformSign)
                    {
                        pantryLogic.AddPoint();
                        Destroy(ingredient);
                    }
                }
                foreach (RatBehaviour rat in activeRats)
                {
                    if (rat != null && rat.transform.position.x >= halfScreenWidth)
                    {
                        Destroy(rat);
                    }
                }

                yield return null;
            }
        }
    }
}
