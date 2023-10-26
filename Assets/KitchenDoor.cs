using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KitchenDoor : MonoBehaviour
{
    public KitchenUI KitchenUI;

    private void OnMouseDown()
    {
        if (!KitchenUI.MainPanel.activeSelf)
        {
            SceneManager.LoadScene("FrontOfHouse");
        }
    }

}
