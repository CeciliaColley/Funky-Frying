using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Actions_MainMenuButton : MonoBehaviour
{
    [SerializeField] private KitchenInputs kitchenInputs;
    [SerializeField] private GoToScene goToScene;
    [SerializeField] private string mainMenu = "MainMenu";

    private void Awake()
    {
        kitchenInputs = new KitchenInputs();
    }
    private void Start()
    {
        goToScene = FindObjectOfType<GoToScene>();
    }

    private void OnEnable()
    {
        if (kitchenInputs != null)
        {
            kitchenInputs.Enable();
            kitchenInputs.KitchenControllerInputs.MainMenu.performed += ctx => GoToMainMenu();
        }
    }

    private void OnDisable()
    {
        if (kitchenInputs != null)
        {
            kitchenInputs.Disable();
            kitchenInputs.KitchenControllerInputs.MainMenu.performed -= ctx => GoToMainMenu();
        }
    }

    private void GoToMainMenu()
    {
        if (goToScene != null)
        {
            goToScene.OpenScene(mainMenu);
        }
    }
}
