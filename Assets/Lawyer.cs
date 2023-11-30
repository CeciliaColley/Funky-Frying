using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Lawyer : MonoBehaviour
{
    [SerializeField] public LawyerUIManagement uiManagement;
    [SerializeField] public Flash flash;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private void OnMouseDown()
    {
        spriteRenderer.color = Color.white;
        if (StaticManager.Instance.lawyerDialogueTracker == 0)
        {
            //TODO: TP2 - Fix - Possible null reference
            if (uiManagement != null)
            {
                uiManagement.MainPanel.SetActive(true);
                uiManagement.nextButton.SetActive(false);
                uiManagement.RuggieroImage.SetActive(false);
            }
            
            //TODO: TP2 - Fix - Possible null reference
            if (flash != null)  { flash.isFlashing = false; }
            
        }
        else
        {
            if (uiManagement != null) { uiManagement.DisplayDialogue();}
        }
    }


    void Start()
    {
        uiManagement = GameObject.FindAnyObjectByType<LawyerUIManagement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        flash = GetComponent<Flash>();
        if (StaticManager.Instance.lawyerDialogueTracker == 0)
        {
            //TODO: TP2 - Fix - Possible null reference
            if (flash != null) { flash.isFlashing = true; }
        }
    }

    //TODO: TP1 - Unused method/variable
}
