using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class KitchenUI : MonoBehaviour
{
    //TODO: TP1 - Unused method/variable
    [SerializeField] public GameObject MainPanel;
    [SerializeField] public GameObject LearnButton;
    [SerializeField] public GameObject CookButton;
    //TODO: TP1 - Unused method/variable

    //TODO: TP2 - Remove redundant comments
    void Start()
    {
        MainPanel.SetActive(false);
    }

    //TODO: TP2 - Fix - Repeated method with the same logic in multiple places.
}
