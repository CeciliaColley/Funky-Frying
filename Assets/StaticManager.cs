using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticManager : MonoBehaviour
{
    // Start() and Update() methods deleted - we don't need them right now

    public static StaticManager Instance;
    public int dialogueTracker;
    public bool videoPlayed = false;
    public bool knowsPomodoro = false;
    public bool isServing = false;
    public bool hasOrdered = false;
    public int playerScore;
    public float speed = 5; // Speed of vegetables
    public float deadZone = 20; // Position at which vegetables are destroyed

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
