using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticManager : MonoBehaviour
{

    [SerializeField] public static StaticManager Instance;
    [SerializeField] public int lawyerDialogueTracker = 0;
    [SerializeField] public bool videoPlayed = false;
    [SerializeField] public bool knowsPomodoro = false;
    [SerializeField] public bool isServing = false;
    [SerializeField] public bool hasOrdered = false;
    [SerializeField] public int playerScore;
    [SerializeField] public float speed = 5;
    [SerializeField] public float deadZone = 20;
    [SerializeField] public bool lawyerIsDining = true;
    [SerializeField] public bool influencerIsDining = false;
    [SerializeField] public bool influencerIsOrdering = false;
    [SerializeField] public bool influencerHasOrdered = false;
    [SerializeField] public int influencerDialogueTracker = 0;

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
