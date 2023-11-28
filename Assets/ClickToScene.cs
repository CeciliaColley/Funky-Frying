using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class ClickToScene : MonoBehaviour
{
    [SerializeField] private string sceneToLoad = "";

    private void OnMouseDown()
    {
        if (StaticManager.Instance.hasOrdered == true )
        {
            //TODO: Fix - Hardcoded value - Serialize string to be able to reuse this script
            SceneManager.LoadScene(sceneToLoad);
        }
    }

}
