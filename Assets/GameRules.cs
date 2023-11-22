using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class GameRules : MonoBehaviour
{
    public int PlayerScore = 0;
    public int PerfectScore = 1;
    public Text ScoreText;
    public Text Percentage;
    public GameObject scorePanel;
    public GameObject perfect;
    public GameObject great;
    public GameObject good;
    public GameObject ok;
    public GameObject cantServe;
    public GameObject tryAgain;
    public GameObject serve;
    public int tempo = 118; // Tempo of the song
    
    public int BeatsInSong = 164;
    public AudioSource Music;
    public float audioLength;
    public int percentage;

    void Start()
    {
        scorePanel.SetActive(false);
        audioLength = Music.clip.length;
    }

    void Update()
    {
        //TODO: Fix - Remove redundant comments
        // Check if the audio has reached its end
        if (Music.time >= audioLength)
        {
            // Perform actions or trigger events when the audio ends
            OnMusicEnd();
        }
    }

    void OnMusicEnd()
    {
        Debug.Log("Music Ended, show UI now");
        if (PlayerScore != 0)
        {
            percentage = PlayerScore * 100 / BeatsInSong;
        }
        else percentage = 0;

        StaticManager.Instance.playerScore = percentage;
        
        Percentage.text = percentage.ToString() + "%";
        
        scorePanel.SetActive(true);
        perfect.SetActive(false);
        great.SetActive(false);
        good.SetActive(false);
        ok.SetActive(false);
        cantServe.SetActive(false);

        //TODO: Fix - Simplify, we can talk about this in class
        if (percentage == 100)
        {
            perfect.SetActive(true);
            Debug.Log("Perfect");
        } else if (percentage >= 90 && percentage <= 99)
        {
            great.SetActive(true);
            Debug.Log("Great");
        } else if (percentage >= 80 && percentage <= 89)
        {
            good.SetActive(true);
            Debug.Log("Good");
        } else if (percentage >= 70 && percentage <= 79)
        {
            ok.SetActive(true);
            Debug.Log("Ok");
        } else if (percentage <= 69)
        {
            cantServe.SetActive(true);
            serve.SetActive(false);
            Debug.Log("Can't Serve");
        }


    }

    public void AddScore(int Score)
    {
        PlayerScore = PlayerScore + Score;
        if (ScoreText != null )
        {
            ScoreText.text = PlayerScore.ToString();
        }
    }
}
