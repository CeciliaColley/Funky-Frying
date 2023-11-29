using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class DoorToKitchenBehaviour : MonoBehaviour
{
    [SerializeField] private GoToScene goToScene;
    [SerializeField] private string sceneToLoad = "Kitchen";

    private void OnMouseDown()
    {
        if (StaticManager.Instance.hasOrdered == true )
        {
            //TODO: Fix - Hardcoded value - Serialize string to be able to reuse this script
            goToScene.OpenScene(sceneToLoad);
        }
    }

    private void Start()
    {
        goToScene = GameObject.FindAnyObjectByType<GoToScene>();
    }
}
