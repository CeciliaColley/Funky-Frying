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
            UIManagement.MainPanel.SetActive(true);
            UIManagement.nextButton.SetActive(false);
            UIManagement.RuggieroImage.SetActive(false);
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
            Flash.isFlashing = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
