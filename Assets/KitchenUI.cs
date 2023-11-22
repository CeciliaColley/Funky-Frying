using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KitchenUI : MonoBehaviour
{
    //TODO: TP1 - Unused method/variable
    public GameObject Canvas;
    public GameObject MainPanel;
    public GameObject LearnButton;
    public GameObject CookButton;
    //TODO: TP1 - Unused method/variable
    public GameObject ExitButton;

    //TODO: TP2 - Remove redundant comments
    // Start is called before the first frame update
    void Start()
    {
        MainPanel.SetActive(false);
    }

    //TODO: TP2 - Fix - Repeated method with the same logic in multiple places.
    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Exit()
    {
        MainPanel.SetActive(false);
    }
}
