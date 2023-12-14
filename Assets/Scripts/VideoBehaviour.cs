using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoBehaviour : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private RawImage rawImage;


    void Start()
    {
        if (StaticManager.Instance.introVideoFinished == false)
        {
            if (videoPlayer != null) { videoPlayer.loopPointReached += OnVideoEnd; }
        }
        else
        {
            OnVideoEnd(videoPlayer);
        }

    }

    void OnVideoEnd(VideoPlayer vp)
    {
        StaticManager.Instance.introVideoFinished = true;
        if (rawImage != null) { Destroy(rawImage); }
        if (videoPlayer != null) { Destroy(videoPlayer); }
    }
  
}
