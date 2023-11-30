using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DIsapearingUI : MonoBehaviour
{
    [SerializeField] private GameRules gameRules;
    [SerializeField] public GameObject ButtonDisplay;
    void Start()
    {
        StartCoroutine(UIDissapears());
    }

    IEnumerator UIDissapears()
    {
        yield return new WaitUntil(() => (gameRules.playerScore == gameRules.beatsInSong/2));
        ButtonDisplay.SetActive(false);

    }
}
