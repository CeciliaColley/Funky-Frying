using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class LawyerBehaviour : MonoBehaviour
{

    [SerializeField] private Flash flash;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private LawyerUIManager lawyerUIManager;
    [SerializeField] private int dialogueUninitiated = 0;
    [SerializeField] private string sceneToResetProperties = "FrontOfHouse";

    void Start()
    {
        lawyerUIManager = GameObject.FindObjectOfType<LawyerUIManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        flash = GetComponent<Flash>();
        if (StaticManager.Instance.lawyerDialogueTracker == dialogueUninitiated && flash != null) { flash.isFlashing = true; }
        StartCoroutine(StopFlashing());
    }
    private void OnMouseDown()
    {
        Interact();
    }

    public void Interact()
    {
        if (lawyerUIManager != null && !lawyerUIManager.lawyerCanvas.activeSelf) { lawyerUIManager.DisplayDialogue(); }
    }

    IEnumerator StopFlashing()
    {
        yield return new WaitUntil(() => lawyerUIManager.clicked);
        if (flash != null) { flash.isFlashing = false; }
        if (spriteRenderer != null) { spriteRenderer.color = Color.white; }
    }

    // After serving the customer reset their values for the next time they dine.
    private void OnDestroy()
    {
        if (StaticManager.Instance.isServing)
        {
            StaticManager.Instance.isServing = false;
            StaticManager.Instance.lawyerIsDining = false;
            StaticManager.Instance.hasOrdered = false;
        }
    }
}