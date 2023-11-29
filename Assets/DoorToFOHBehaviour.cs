using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class DoorToFOHBehaviour : MonoBehaviour
{
    [SerializeField] private KitchenUI KitchenUI;
    [SerializeField] private GoToScene goToScene;
    [SerializeField] private string sceneToLoad = "FrontOfHouse";

    private void OnMouseDown()
    {
        if (KitchenUI != null)
        {
            if (!KitchenUI.MainPanel.activeSelf) { goToScene.OpenScene(sceneToLoad); }
        }
        
    }

}
