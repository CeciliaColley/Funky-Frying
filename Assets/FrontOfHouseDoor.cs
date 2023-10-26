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
            SceneManager.LoadScene("Kitchen");
        }
    }

}
