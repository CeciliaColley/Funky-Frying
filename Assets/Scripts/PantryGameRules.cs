using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PantryGameRules : MonoBehaviour
{
    public int ratsEscaped = 0; // Referenced by PantryCheats
    public bool gameEnded = false; // Referenced by PantryIngredientSpawner and RatSpawner
    public int ingredientsSaved = 0; // Referenced by PantryCheats
    public bool startGame = false; // Referenced by PantryRaySpawner and PantryIngredientSpawner


    [SerializeField] private int requiredIngredients = 15;
    [SerializeField] private int lostIngredientsLimit = -5;
    [SerializeField] private int escapedRatLimit = 5;
    [SerializeField] private int basketSpriteCounter = 0;
    [SerializeField] private int basketSpriteMax = 8;
    [SerializeField] private int clean = 0;
    [SerializeField] private Text ingredientsSavedText;
    [SerializeField] private Text ratsLooseText;
    [SerializeField] private Text endScreenRatsEscapedWin;
    [SerializeField] private Text endScreenRatsEscapedLoss;
    [SerializeField] private Button instructionsUnderstood;
    [SerializeField] private Button backToKitchenWin;
    [SerializeField] private Button backToKitchenLoss;
    [SerializeField] private GameObject instructions;
    [SerializeField] private GameObject grime1;
    [SerializeField] private GameObject grime2;
    [SerializeField] private GameObject grime3;
    [SerializeField] private GameObject grime4;
    [SerializeField] private GameObject grime5;
    [SerializeField] private GameObject[] grimeObjects;
    [SerializeField] private GameObject endScreenWin;
    [SerializeField] private GameObject endScreenLoss;
    [SerializeField] private GameObject inGameUI;
    [SerializeField] private BasketBehaviour basket;
    [SerializeField] private PolygonCollider2D lossPointCollider;
    [SerializeField] private LossPoint lossPoint;
    [SerializeField] private enum GameState { LOST, WON};
    [SerializeField] private GameState gameState;

    private void Start()
    {
        lossPoint = FindObjectOfType<LossPoint>();
        if (lossPoint != null) { lossPointCollider = lossPoint.GetComponent<PolygonCollider2D>(); }
        grimeObjects = new GameObject[] { grime1, grime2, grime3, grime4, grime5 };

        if (grime1 != null) grime1.SetActive(false);
        if (grime2 != null) grime2.SetActive(false);
        if (grime3 != null) grime3.SetActive(false);
        if (grime4 != null) grime4.SetActive(false);
        if (grime5 != null) grime5.SetActive(false);
        if (endScreenWin != null) endScreenWin.SetActive(false);
        if (endScreenLoss != null) endScreenLoss.SetActive(false);
        if (instructionsUnderstood != null) instructionsUnderstood.Select();


        StartCoroutine(AddGrime());
        StartCoroutine(EndGame());
    }
    IEnumerator EndGame()
    {
        while (!gameEnded)
        {
            if (ingredientsSaved >= requiredIngredients && ratsEscaped <= escapedRatLimit)
            {
                gameState = GameState.WON;
                gameEnded = true;
            }
            else if (ingredientsSaved < requiredIngredients && ratsEscaped >= escapedRatLimit)
            {
                gameState = GameState.LOST;
                gameEnded = true;
            } else if (ingredientsSaved <= lostIngredientsLimit)
            {
                gameState = GameState.LOST;
                gameEnded = true;
            }
            yield return null;
        }
        if (gameEnded && lossPointCollider != null)
        {
            Destroy(lossPointCollider);
            if (gameState == GameState.WON) 
            {
                if (inGameUI != null) inGameUI.SetActive(false);
                if (endScreenRatsEscapedWin != null) endScreenRatsEscapedWin.text = ratsEscaped.ToString();
                if (endScreenWin != null) endScreenWin.SetActive(true);
                StaticManager.Instance.pantryDirtiness = clean;
                if (backToKitchenWin != null) backToKitchenWin.Select();
            }
            if (gameState == GameState.LOST)
            {
                if (inGameUI != null) inGameUI.SetActive(false);
                if (endScreenRatsEscapedLoss != null) endScreenRatsEscapedLoss.text = ratsEscaped.ToString();
                if (endScreenLoss != null) endScreenLoss.SetActive(true);
                if (backToKitchenLoss != null) backToKitchenLoss.Select();

            }
        }
    }

    IEnumerator AddGrime()
    {
        while (!gameEnded)
        {
            int grimeCount = Mathf.Max(-ingredientsSaved, ratsEscaped);

            for (int i = 0; i < grimeObjects.Length; i++)
            {
                if (grimeObjects[i] != null) { grimeObjects[i].SetActive(i < grimeCount); }
            }

            yield return null;
        }
    }
    public void AddPoint()
    {
        if (ingredientsSavedText != null) { ingredientsSavedText.text = ingredientsSaved.ToString() + " / " + requiredIngredients; }
        ingredientsSaved++;
        if (ingredientsSavedText != null) {ingredientsSavedText.text = ingredientsSaved.ToString() + " / " + requiredIngredients; }
        if (basket != null && basketSpriteCounter <= basketSpriteMax)
        {
            basket.ingredients[basketSpriteCounter].SetActive(true);
            basketSpriteCounter++;
        }
    }

    public void SubtractPoint()
    {
        if (ingredientsSavedText != null) { ingredientsSavedText.text = ingredientsSaved.ToString() + " / " + requiredIngredients; }
        ingredientsSaved--;
        if (ingredientsSavedText != null) { ingredientsSavedText.text = ingredientsSaved.ToString() + " / " + requiredIngredients; }
    }

    public void AddEscapedRat()
    {
        if (ratsLooseText != null) { ratsLooseText.text = ratsEscaped.ToString() + "/ " + escapedRatLimit; }
        ratsEscaped++;
        if (ratsLooseText != null) { ratsLooseText.text = ratsEscaped.ToString() + " / " + escapedRatLimit; }
    }

    public void StartGame()
    {
        if (instructions != null) { instructions.SetActive(false); }
        startGame = true;
    }
}
