using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PantryIngredientSpawner : MonoBehaviour
{
    [SerializeField] private PantryGameRules pantryLogic;
    [SerializeField] private RatTrapBehaviour ratTrap;
    [SerializeField] private GameObject[] ingredients;
    [SerializeField] private GameObject ingredient1;
    [SerializeField] private GameObject ingredient2;
    [SerializeField] private GameObject ingredient3;
    [SerializeField] private GameObject ingredient4;
    [SerializeField] private GameObject ingredient5;
    [SerializeField] private GameObject ingredient6;
    [SerializeField] private GameObject ingredient7;
    [SerializeField] private GameObject ingredient8;
    [SerializeField] private GameObject ingredient9;
    [SerializeField] private GameObject ingredient10;
    [SerializeField] private GameObject ingredient11;
    [SerializeField] private GameObject ingredient12;
    [SerializeField] private GameObject ingredient13;
    [SerializeField] private GameObject ingredient14;
    [SerializeField] private float spawnSpeed = 0.75f;
    [SerializeField] private float ratTrapWidth = 1f;
    [SerializeField] private float halfScreenWidth;
    [SerializeField] private float rightLimit;
    [SerializeField] private float leftLimit;

    private void Start()
    {
        // Initialize array with appropriate ingredients in engine
        ingredients = new GameObject[] {
            ingredient1, ingredient2, ingredient3, ingredient4, ingredient5,
            ingredient6, ingredient7, ingredient8, ingredient9, ingredient10,
            ingredient11, ingredient12, ingredient13, ingredient14
        };

        if (ratTrap != null) { ratTrapWidth = ratTrap.GetComponent<Renderer>().bounds.size.x; }
        halfScreenWidth = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        StartCoroutine(SpawnIngredients());
    }
    IEnumerator SpawnIngredients()
    {
        if (pantryLogic != null)
        {
            yield return new WaitUntil(() => pantryLogic.startGame);
            while (!pantryLogic.gameEnded)
            {
                yield return new WaitForSeconds(spawnSpeed);

                // Randomly choose an ingredient to spawn and find half it's width
                int ingredientToSpawn = Random.Range(0, ingredients.Length);
                float IngredientWidth = (ingredients[ingredientToSpawn].GetComponent<Renderer>().bounds.size.x);

                // Use the ingredient's width to define a spawnRange, ensuring not to spawn on top of the rat trap.
                rightLimit = halfScreenWidth - ratTrapWidth - IngredientWidth;
                leftLimit = -(halfScreenWidth - (IngredientWidth));
                float randomX = Random.Range(leftLimit, rightLimit);
                Vector3 spawnPosition = new(randomX, transform.position.y, transform.position.z);

                //Spawn the ingredient
                if (ingredients != null)
                {
                    Instantiate(ingredients[ingredientToSpawn], spawnPosition, Quaternion.identity);
                }
            }
        }
        
    }
}
