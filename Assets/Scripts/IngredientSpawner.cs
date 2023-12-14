using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSpawner : MonoBehaviour
{
    [SerializeField] private CookingGameRules gameRules;
    [SerializeField] private Actions_CookingCheats cookingCheats;
    [SerializeField] private GameObject ingredient1;
    [SerializeField] private GameObject ingredient2;
    [SerializeField] private GameObject ingredient3;
    [SerializeField] private GameObject ingredient4;
    [SerializeField] private GameObject[] ingredients;
    [SerializeField] private AudioSource music;
    [SerializeField] private int ingredientsSpawned = 0;
    [SerializeField] private float tempoDenominator = 60.0f; // Denominator of tempo. If tempo is measured in beats per minute it is 60. If tempo is measure in beats per second, it is 1.
    [SerializeField] private float spawnRate = 0.0f;
    [SerializeField] private float cheatInterval = 1.0f;
    [SerializeField] private float musicThreshold = 1.0f;

    void Start()
    {
        cookingCheats = FindObjectOfType<Actions_CookingCheats>();
        
        // Erase previous game's score, and restart player's score to 0.
        StaticManager.Instance.playerScore = 0;

        // Calculate the spawnrate based on the song's tempo, and load array with the appropriate ingredients in engine.
        if (gameRules != null) { spawnRate = tempoDenominator / gameRules.tempo; } 
        ingredients = new GameObject[] { ingredient1, ingredient2, ingredient3, ingredient4 };
        
        StartCoroutine(SpawnIngredients());
        StartCoroutine(PlaySong());
    }

    // Wait until first vegetable is chopped, then play music. Punish player for previously missed chops.
    private IEnumerator PlaySong()
    {
        if (gameRules != null)
        {
            yield return new WaitUntil(() => gameRules.playerScore >= musicThreshold);
            if (music != null) { music.Play(); }
            gameRules.beatsInSong = ingredientsSpawned + gameRules.beatsInSong;
        }
            
    }

    // Spawn ingredients with the approriate interval
    private IEnumerator SpawnIngredients()
    {
        if (gameRules != null && cookingCheats != null)
        {
            while (ingredientsSpawned < gameRules.beatsInSong)
            {
                if (!cookingCheats.slowDown)
                {
                    yield return new WaitForSeconds(spawnRate);
                    SpawnIngredient();
                }
                else
                {
                    yield return new WaitForSeconds(cheatInterval);
                    SpawnIngredient();
                }
                yield return null;
            }
        }
    }

    // Choose a random ingredient to spawn and keep track of how many have been spawned to accurately calculate user's final score.
    private void SpawnIngredient()
    {
        if (ingredients != null)
        {
            int i = Random.Range(0, ingredients.Length);
            Instantiate(ingredients[i], transform.position, transform.rotation);
            ingredientsSpawned++;
        }
    }
}
