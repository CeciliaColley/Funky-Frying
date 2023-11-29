using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticManager : MonoBehaviour
{

    [SerializeField] public static StaticManager Instance;
    [SerializeField] public int dialogueTracker = 0;
    [SerializeField] public bool videoPlayed = false;
    [SerializeField] public bool knowsPomodoro = false;
    [SerializeField] public bool isServing = false;
    [SerializeField] public bool hasOrdered = false;
    [SerializeField] public int playerScore;
    [SerializeField] public float speed = 5;
    [SerializeField] public float deadZone = 20;
    [SerializeField] public bool lawyerIsDining = true;

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
}
