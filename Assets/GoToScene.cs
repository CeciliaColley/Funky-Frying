using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour
{
    public void OpenScene(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    //TODO: TP2 - Fix - This method doesn't belong in this class
   
}
