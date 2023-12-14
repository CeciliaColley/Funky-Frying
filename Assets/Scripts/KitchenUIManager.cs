using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class KitchenUIManager : MonoBehaviour
{
    public GameObject pastaMainMenu; // Referenced by DoorToFOHBehaviour, and RecipeBookBehaviour
    public GameObject pastaLearnButton; // Referenced by RecipeBookBehaviour
    public GameObject pastaCookButton; // Referenced by RecipeBookBehaviour
    public GameObject kaleRecipe; // Referenced by DoorToFOHBehaviour, and RecipeBookBehaviour
    public GameObject kaleCookButton; // Referenced by RecipeBookBehaviour
    public Button pastaEmptyButton; // Referenced by RecipeBookBehaviour
    public Button kaleEmptyButton; // Referenced by RecipeBookBehaviour

    private void Start()
    {
        if (pastaMainMenu != null) { pastaMainMenu.SetActive(false); }
        if (kaleRecipe != null) { kaleRecipe.SetActive(false); }
    }
}

