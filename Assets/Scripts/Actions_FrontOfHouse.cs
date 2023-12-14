using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Actions_FrontOfHouse : MonoBehaviour
{ 
    [SerializeField] private CustomInput input;
    [SerializeField] private GoToScene goToScene;
    [SerializeField] private InfluencerUIManager influencerUIManager;
    [SerializeField] private LawyerUIManager lawyerUIManager;
    [SerializeField] private GeneralUIManager generalUIManager;
    [SerializeField] private string kitchen = "Kitchen";
    [SerializeField] private string frontOfHouse = "FrontOfHouse";
    [SerializeField] private string mainMenu = "MainMenu";

    private void Awake()
    {
        // Initialize input
        input = new CustomInput();
    }

    private void Start()
    {
        // Find necessary managers in the scene
        goToScene = FindObjectOfType<GoToScene>();
        lawyerUIManager = FindObjectOfType<LawyerUIManager>();
        influencerUIManager = FindObjectOfType<InfluencerUIManager>();
        generalUIManager = FindObjectOfType<GeneralUIManager>();
    }

    private void OnEnable()
    {
        // Enable input and attach event handlers
        if (input != null)
        {
            input.Enable();
            input.InteractionWithController.GoToMainMenu.performed += ctx => GoToMainMenu();
            input.InteractionWithController.InteractWithCustomer.canceled += ctx => InteractWithCustomer();
            input.InteractionWithController.ChangeScene.performed += ctx => ChangeScene();
            input.InteractionWithController.OpenClipboard.performed += ctx => OpenClipboard();
        }
    }

    private void OnDisable()
    {
        // Disable input and detach event handlers
        if (input != null)
        {
            input.Disable();
            input.InteractionWithController.GoToMainMenu.performed -= ctx => GoToMainMenu();
            input.InteractionWithController.InteractWithCustomer.canceled -= ctx => InteractWithCustomer();
            input.InteractionWithController.ChangeScene.performed -= ctx => ChangeScene();
            input.InteractionWithController.OpenClipboard.performed -= ctx => OpenClipboard();
        }
    }

    private void InteractWithCustomer()
    {
        // Display dialogue for influencer or lawyer if they are dining
        if (StaticManager.Instance.influencerIsDining && influencerUIManager != null)
        {
            influencerUIManager.DisplayDialogue(); 
            influencerUIManager.SelectFirstButton(); 
        }
        if (StaticManager.Instance.lawyerIsDining && lawyerUIManager != null && !lawyerUIManager.clicked)
        {
            lawyerUIManager.DisplayDialogue(); 
            lawyerUIManager.SelectFirstButton();
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

    private void ChangeScene()
    {
        // Change the scene between kitchen and frontOfHouse based on the current scene
        Scene currentScene = SceneManager.GetActiveScene();
        if (goToScene != null && currentScene != null)
        {
            if (currentScene.name == frontOfHouse) { goToScene.OpenScene(kitchen); }
            if (currentScene.name == kitchen) { goToScene.OpenScene(frontOfHouse); }
        }
    }

    private void OpenClipboard()
    {
        // Open the clipboard in the frontOfHouse scene using GeneralUIManager
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene != null && generalUIManager != null)
        {
            if (currentScene.name == frontOfHouse)
            {
                generalUIManager.OpenClipboard(); 
            }
        }
    }
}
