using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Lawyer : MonoBehaviour
{
    public UIManagement UIManagement;
    public Flash Flash;
    private void OnMouseDown()
    {
        if (StaticManager.Instance.dialogueTracker == 0)
        {
            //TODO: TP2 - Fix - Possible null reference
            if (UIManagement != null)
            {
                UIManagement.MainPanel.SetActive(true);
                UIManagement.nextButton.SetActive(false);
                UIManagement.RuggieroImage.SetActive(false);
            }
            
            //TODO: TP2 - Fix - Possible null reference
            if (Flash != null)  { Flash.isFlashing = false; }
            
        }
        else
        {
            if (UIManagement != null) { UIManagement.DisplayDialogue(); }
        }
    }


    void Start()
    {
        UIManagement = GameObject.FindAnyObjectByType<UIManagement>();
        Flash = GetComponent<Flash>();
        if (StaticManager.Instance.dialogueTracker == 0)
        {
            //TODO: TP2 - Fix - Possible null reference
            if (Flash != null) { Flash.isFlashing = true; }
        }
    }

    //TODO: TP1 - Unused method/variable
}
