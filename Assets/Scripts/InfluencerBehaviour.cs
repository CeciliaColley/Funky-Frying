using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfluencerBehaviour : MonoBehaviour
{
    [SerializeField] private InfluencerUIManager influencerUIManager;
    [SerializeField] private GeneralUIManager generalUI;
    [SerializeField] private GameObject influencerCanvas;

    private void Start()
    {
        influencerUIManager = GameObject.FindObjectOfType<InfluencerUIManager>();
        generalUI = GameObject.FindObjectOfType<GeneralUIManager>();
    }

    private void OnMouseDown()
    {
        // When the UI is on top of the influencer, ignore input, and only listen to UI input
        if (influencerUIManager != null && !influencerUIManager.influencerCanvas.activeSelf && !generalUI.showClipboard)
        {
            influencerUIManager.DisplayDialogue();
        }
    }

    private void OnDestroy()
    {
        if (StaticManager.Instance.isServing)
        {
            StaticManager.Instance.isServing = false;
            StaticManager.Instance.influencerIsDining = false;
            StaticManager.Instance.hasOrdered = false;
        }
    }
}
