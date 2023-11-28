using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KitchenUI : MonoBehaviour
{
    //TODO: TP1 - Unused method/variable
    public GameObject MainPanel;
    public GameObject LearnButton;
    public GameObject CookButton;
    //TODO: TP1 - Unused method/variable

    //TODO: TP2 - Remove redundant comments
    void Start()
    {
        HideMainPanel();
    }

    //TODO: TP2 - Fix - Repeated method with the same logic in multiple places.
    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void HideMainPanel()
    {
        MainPanel.SetActive(false);
    }
}
