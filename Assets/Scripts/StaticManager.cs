using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaticManager : MonoBehaviour
{

    public static StaticManager Instance;
    public int lawyerDialogueTracker = 0; // Referenced by LawyerBehaviour and LawyerUIManager
    public int influencerDialogueTracker = 0; // Referenced by InfluencerUIManager
    public int pantryDirtiness = 0; //Referenced by GeneralUIManager
    public float speed = 5; // Referenced by VegetableScript
    public float deadZone = 20; // Referenced by VegetableScript
    public bool tutorialCompleted = false; // Referenced by RecipeBook and TutorialVegetableSpawner
    public bool isServing = false; // Referenced by CookingGameRUles, InfluencerBehaviour, InfluencerUIManager, LawyerBehaviour and LawyerUIManager
    public bool hasOrdered = false; // Referenced by InfluencerBehaviour, InfluencerUIManager, LawyerBehaviour and LawyerUIManager
    public int playerScore = 0; // Referenced by InfluencerUIManager, LawyerUIManager, CookingGameRules, and IngredientSpawner
    public bool lawyerIsDining = true; // Referenced by Actions_FrontOfHouse, LawyerBehaviour, LawyerSpawner, LawyerUIManager and RecipeBook
    public bool influencerIsDining = false; // Referenced by Action_FrontOfHouse, InfluencerSpawner, and RecipeBook
    public bool introVideoFinished = false; // Referenced by VideoBehaviour, and LawyerSpawner
    public bool lawyerDined = false; // Referenced by GeneralUIManager and LawyerUI
    public bool influencerDined = false; // Referenced by GeneralUIManager and InfluencerUIManager
    public int playerMoney = 0; //Referenced by GeneralUIManager
    public float experience = 0.1f; // Referenced by CookingGameRules
    public int pendingCoins; // Referenced by GeneralUIManager



    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        StartCoroutine(SpawnInfluencer());
    }

    IEnumerator SpawnInfluencer()
    {
        yield return new WaitUntil(() => !lawyerIsDining);
        yield return new WaitForSeconds(1.0f);
        influencerIsDining = true;
    }

    
}
