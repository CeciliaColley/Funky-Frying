using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class KitchenDoor : MonoBehaviour
{
    [SerializeField] private KitchenUI KitchenUI;
    [SerializeField] private string sceneToLoad;

    private void OnMouseDown()
    {
        if (!KitchenUI.MainPanel.activeSelf)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }

}
