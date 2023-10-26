using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoBehaviour : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public RawImage RawImage;


    void Start()
    {
        if (StaticManager.Instance.videoPlayed == false)
        {
            videoPlayer.loopPointReached += OnVideoEnd;
            StaticManager.Instance.videoPlayed = true;
        }
        else
        {
            OnVideoEnd(videoPlayer);
        }

    }

   void OnVideoEnd(VideoPlayer vp)
    {
        Destroy(RawImage);
        Destroy(videoPlayer);
    }
}
