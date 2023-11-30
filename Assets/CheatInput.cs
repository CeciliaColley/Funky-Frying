using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatInput : MonoBehaviour
{
    [SerializeField] private CheatControls cheats;
    [SerializeField] private GameRules gameRules;
    [SerializeField] private IngredientSpawner ingredientSpawner;

    private void Start()
    {
        gameRules = GameObject.FindAnyObjectByType<GameRules>();
    }
    

    private void OnEnable()
    {
        if (cheats == null)
        {
            cheats = new CheatControls();
            cheats.CustomCheatControls.Enable();
        }

        cheats.CustomCheatControls.Win.performed += ctx => WinAction();
        cheats.CustomCheatControls.SlowDown.performed += ctx => SlowDownAction();
        cheats.CustomCheatControls.ChangePosition.performed += ctx => ChangePositionAction();
    }

    private void OnDisable()
    {
        cheats.CustomCheatControls.Win.performed -= ctx => WinAction();
        cheats.CustomCheatControls.SlowDown.performed -= ctx => SlowDownAction();
        cheats.CustomCheatControls.ChangePosition.performed -= ctx => ChangePositionAction();
    }

    private void WinAction()
    {
        gameRules.audioLength = 1;
        gameRules.playerScore = gameRules.beatsInSong;
    }

    private void SlowDownAction()
    {
        StaticManager.Instance.slowDown = !StaticManager.Instance.slowDown;
    }

    public void ChangePositionAction()
    {
        Debug.Log("cecilia");
        StaticManager.Instance.automaticKill = !StaticManager.Instance.automaticKill;
    }
}
