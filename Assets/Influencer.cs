using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Influencer : MonoBehaviour
{
    [SerializeField] private InfluencerUIManager InfluencerUIManager;

    private void Start()
    {
        InfluencerUIManager = GameObject.FindAnyObjectByType<InfluencerUIManager>();
    }

    private void OnMouseDown()
    {
        InfluencerUIManager.displayDialogue();
    }
}
