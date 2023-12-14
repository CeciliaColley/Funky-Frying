using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

// Warning! Erasing the reference to kitchenUI causes unexpected behaviour.

public class Actions_Kitchen : MonoBehaviour
{
    [SerializeField] private KitchenInputs kitchenInputs;
    [SerializeField] private KitchenUIManager kitchenUI;
    [SerializeField] private RecipeBookBehaviour recipeBook;
    [SerializeField] private GoToScene goToScene;
    [SerializeField] private string scene = "FrontOfHouse";
    [SerializeField] private string mainMenu = "MainMenu";

    private void Awake()
    {
        // Initialize kitchenInputs
        kitchenInputs = new KitchenInputs();
    }
    void Start()
    {
        // Find necessary managers in the scene
        kitchenUI = FindObjectOfType<KitchenUIManager>();
        goToScene = FindObjectOfType<GoToScene>();
        recipeBook = FindObjectOfType<RecipeBookBehaviour>();
    }

    private void OnEnable()
    {
        // Enable kitchenInputs and attach event handlers
        if (kitchenInputs != null)
        {
            kitchenInputs.Enable();
            kitchenInputs.KitchenControllerInputs.GoToFrontOfHouse.performed += ctx => GoToFrontOfHouseAction();
            kitchenInputs.KitchenControllerInputs.OpenRecipeBook.performed += ctx => OpenRecipeBookAction();
            kitchenInputs.KitchenControllerInputs.MainMenu.performed += ctx => GoToMainMenu();
        }
    }

    private void OnDisable()
    {
        // Disable kitchenInputs and detach event handlers
        if (kitchenInputs != null)
        {
            kitchenInputs.Disable();
            kitchenInputs.KitchenControllerInputs.GoToFrontOfHouse.performed -= ctx => GoToFrontOfHouseAction();
            kitchenInputs.KitchenControllerInputs.OpenRecipeBook.performed -= ctx => OpenRecipeBookAction();
            kitchenInputs.KitchenControllerInputs.MainMenu.performed -= ctx => GoToMainMenu();
        }
    }

    private void GoToFrontOfHouseAction()
    {
        // Open the "FrontOfHouse" scene using GoToScene
        if (goToScene != null)
        {
            goToScene.OpenScene(scene);
        }
    }

    private void OpenRecipeBookAction()
    {
        // Open the recipe book using RecipeBook
        if (recipeBook != null)
        {
            recipeBook.OpenBook();
        }
    }

    private void GoToMainMenu()
    {
        // Go to the main menu using GoToScene
        if (goToScene != null)
        {
            goToScene.OpenScene(mainMenu);
        }
    }
}
