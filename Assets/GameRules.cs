using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

[System.Serializable]
public class GameRules : MonoBehaviour
{
    [SerializeField] private int playerScore = 0;
    [SerializeField] public int chopPoint = 1;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text percentageString;
    [SerializeField] private GameObject scorePanel;
    [SerializeField] private GameObject perfect;
    [SerializeField] private GameObject great;
    [SerializeField] private GameObject good;
    [SerializeField] private GameObject ok;
    [SerializeField] private GameObject cantServe;
    [SerializeField] private GameObject tryAgain;
    [SerializeField] private GameObject serve;
    [SerializeField] public int tempo = 118;
    
    [SerializeField] public int beatsInSong = 164;
    [SerializeField] private AudioSource music;
    [SerializeField] private float audioLength;
    [SerializeField] private int percentage = 0;

    void Start()
    {
        scorePanel.SetActive(false);
        audioLength = music.clip.length;
    }

    void Update()
    {
        //TODO: Fix - Remove redundant comments
        if (music.time >= audioLength){ OnMusicEnd(); }
    }

    void OnMusicEnd()
    {
        if (playerScore != 0){percentage = playerScore * 100 / beatsInSong;}
        else percentage = 0;

        StaticManager.Instance.playerScore = percentage;

        if (percentageString != null) { percentageString.text = percentage.ToString() + "%"; }

        if (scorePanel != null) { scorePanel.SetActive(true); }
        if (perfect != null) { perfect.SetActive(false); }
        if (great != null) { great.SetActive(false); }
        if (good != null) { good.SetActive(false); }
        if (ok != null) { ok.SetActive(false); }
        if (cantServe != null) { cantServe.SetActive(false); }

        //TODO: Fix - Simplify, we can talk about this in class
        //Note for professor: I did my best to make it better, I hope this was what you were looking for!

        if (percentage == 100 && perfect != null) { perfect.SetActive(true); StaticManager.Instance.isServing = true; } 
        else if (percentage >= 90 && great != null) { great.SetActive(true); StaticManager.Instance.isServing = true; } 
        else if (percentage >= 80 && good != null) {good.SetActive(true); StaticManager.Instance.isServing = true; } 
        else if (percentage >= 70 && ok != null) { ok.SetActive(true); StaticManager.Instance.isServing = true; } 
        else if (percentage <= 69 && cantServe != null && serve != null) { cantServe.SetActive(true); serve.SetActive(false); }

    }

    public void AddScore(int Score)
    {
        playerScore = playerScore + Score;
        if (scoreText != null ){scoreText.text = playerScore.ToString();}
    }
}
