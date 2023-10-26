using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KitchenUI : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject MainPanel;
    public GameObject LearnButton;
    public GameObject CookButton;
    public GameObject ExitButton;

    // Start is called before the first frame update
    void Start()
    {
        MainPanel.SetActive(false);
    }

    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Exit()
    {
        MainPanel.SetActive(false);
    }
}
