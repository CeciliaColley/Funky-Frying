using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketBehaviour : MonoBehaviour
{
    public GameObject[] ingredients; //Referenced by PantryLogic

    [SerializeField] private GameObject ingredient1;
    [SerializeField] private GameObject ingredient2;
    [SerializeField] private GameObject ingredient3;
    [SerializeField] private GameObject ingredient4;
    [SerializeField] private GameObject ingredient5;
    [SerializeField] private GameObject ingredient6;
    [SerializeField] private GameObject ingredient7;
    [SerializeField] private GameObject ingredient8;
    [SerializeField] private GameObject ingredient9;
    

    private void Start()
    {
        // Initialize the ingredients array with references to individual ingredients
        ingredients = new GameObject[] { ingredient1, ingredient2, ingredient3, ingredient4, ingredient5, ingredient6, ingredient7, ingredient8, ingredient9 };
        
        
        foreach (GameObject ingredient in ingredients)
        {
            // Deactivate all ingredients initially
            if (ingredient != null) { ingredient.SetActive(false); }
        }
    }
}
