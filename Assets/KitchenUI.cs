using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class KitchenUI : MonoBehaviour
{
    //TODO: TP1 - Unused method/variable
    [SerializeField] public GameObject PastaMainPanel;
    [SerializeField] public GameObject PastaLearnButton;
    [SerializeField] public GameObject PastaCookButton;
    [SerializeField] public GameObject KaleRecipe;
    [SerializeField] public GameObject KaleCookButton;
    //TODO: TP1 - Unused method/variable

    //TODO: TP2 - Remove redundant comments
    void Start()
    {
        PastaMainPanel.SetActive(false);
        KaleRecipe.SetActive(false);
    }

    //TODO: TP2 - Fix - Repeated method with the same logic in multiple places.
}
