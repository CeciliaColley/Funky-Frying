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
            UIManagement.MainPanel.SetActive(true);
            UIManagement.nextButton.SetActive(false);
            UIManagement.RuggieroImage.SetActive(false);
            //TODO: TP2 - Fix - Possible null reference
            Flash.isFlashing = false;
        }
        else
        {
            UIManagement.DisplayDialogue();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        UIManagement = GameObject.FindAnyObjectByType<UIManagement>();
        Flash = GetComponent<Flash>();
        if (StaticManager.Instance.dialogueTracker == 0)
        {
            //TODO: TP2 - Fix - Possible null reference
            Flash.isFlashing = true;
        }
    }

    //TODO: TP1 - Unused method/variable
    // Update is called once per frame
    void Update()
    {
        
    }
}
