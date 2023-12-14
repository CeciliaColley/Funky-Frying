using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions_CookingCheats : MonoBehaviour
{
    public bool slowDown = false; // Referenced by Ingredient Spawner
    public bool automaticKill = false; // Referenced by Hit Zone

    [SerializeField] private CheatControls cheats;
    [SerializeField] private CookingGameRules gameRules;
    [SerializeField] private IngredientSpawner ingredientSpawner;

    private void Awake()
    {
        // Initialize cheat controls
        cheats = new CheatControls();
    }
    private void Start()
    {
        // Find CookingGameRules in the scene
        gameRules = GameObject.FindObjectOfType<CookingGameRules>();
    }

    private void OnEnable()
    {
        // Enable cheat controls and attach event handlers
        if ( cheats != null)
        {
            cheats.Enable();
            cheats.CustomCheatControls.Win.performed += ctx => WinAction();
            cheats.CustomCheatControls.SlowDown.performed += ctx => SlowDownAction();
            cheats.CustomCheatControls.ChangePosition.performed += ctx => ChangePositionAction();
        }
    }

    private void OnDisable()
    {
        // Disable cheat controls and detach event handlers
        if ( cheats != null)
        {
            cheats.Disable();
            cheats.CustomCheatControls.Win.performed -= ctx => WinAction();
            cheats.CustomCheatControls.SlowDown.performed -= ctx => SlowDownAction();
            cheats.CustomCheatControls.ChangePosition.performed -= ctx => ChangePositionAction();
        }
    }

    private void WinAction()
    {
        // Set audio length to 1 and player score to beatsInSong in gameRules to end the game and win immediately
        if (gameRules != null)
        {
            gameRules.audioLength = 1;
            gameRules.playerScore = gameRules.beatsInSong;
        }
    }

    private void SlowDownAction()
    {
        // Toggle the slowDown flag
        slowDown = !slowDown;
    }

    public void ChangePositionAction()
    {
        // Toggle the automaticKill flag
        automaticKill = !automaticKill;
    }
}
