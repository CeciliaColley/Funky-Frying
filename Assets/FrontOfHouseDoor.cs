using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FrontOfHouseDoor : MonoBehaviour
{
    

    private void OnMouseDown()
    {
        if (StaticManager.Instance.hasOrdered == true )
        {
            //TODO: Fix - Hardcoded value - Serialize string to be able to reuse this script
            SceneManager.LoadScene("Kitchen");
        }
    }

}
