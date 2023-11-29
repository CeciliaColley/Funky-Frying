using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Lawyer : MonoBehaviour
{
    [SerializeField] public UIManagement uiManagement;
    [SerializeField] public Flash flash;
    private void OnMouseDown()
    {
        if (StaticManager.Instance.dialogueTracker == 0)
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
            if (uiManagement != null) { uiManagement.DisplayDialogue(); }
        }
    }


    void Start()
    {
        uiManagement = GameObject.FindAnyObjectByType<UIManagement>();
        flash = GetComponent<Flash>();
        if (StaticManager.Instance.dialogueTracker == 0)
        {
            //TODO: TP2 - Fix - Possible null reference
            if (flash != null) { flash.isFlashing = true; }
        }
    }

    //TODO: TP1 - Unused method/variable
}
