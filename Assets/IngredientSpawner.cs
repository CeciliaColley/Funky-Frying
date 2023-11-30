using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSpawner : MonoBehaviour
{
    [SerializeField] private GameObject Ingredient1;
    [SerializeField] private GameObject Ingredient2;
    [SerializeField] private GameObject Ingredient3;
    [SerializeField] private GameObject Ingredient4;
    [SerializeField] private GameRules GameRules;
    [SerializeField] public float spawnRate;
    [SerializeField] private GameObject[] ingredients;
    [SerializeField] private int ingredientsSpawned = 0;
    [SerializeField] private AudioSource music;

    void Start()
    {
        StaticManager.Instance.isServing = true; 
        StaticManager.Instance.playerScore = 0;
        spawnRate = (float)60/GameRules.tempo;
        ingredients = new GameObject[] { Ingredient1, Ingredient2, Ingredient3, Ingredient4 };
        StartCoroutine(SpawnVegetables());
        StartCoroutine(PlaySong());

        //TODO: TP1 - Unused method/variable - Why is this in multiple scripts? I thought I needed it to use random numbers!
        /* Note for professor: I ended up changing a lot about this, because I got so much feedback from so many people that the game would have 
         been more fun if it started with the entire spectrum of vegetables spawning. I'm not sure if you remember, but previously, 
         the first quarter of the game was only tomatoes, the next quarter was garlic, then basil, then parmesan, etc. Now I've made it so you start with all the
        vegetables from the begining. :)*/
    }

    void Update()
    {
        //TODO: TP2 - Fix - Clean code
        //TODO: TP2 - Could be a coroutine/Invoke
        
    }

    IEnumerator PlaySong()
    {
        yield return new WaitUntil(() => GameRules.playerScore >= 1);
        music.Play();
        GameRules.beatsInSong = ingredientsSpawned + GameRules.beatsInSong;

    }

    IEnumerator SpawnVegetables()
    {
        while (ingredientsSpawned < GameRules.beatsInSong)
        {
            if (!StaticManager.Instance.slowDown)
            {
                yield return new WaitForSeconds(spawnRate);

                int i = Random.Range(0, ingredients.Length);
                Instantiate(ingredients[i], transform.position, transform.rotation);
                ingredientsSpawned++;
            }
            else
            {
                yield return new WaitForSeconds(1);

                int i = Random.Range(0, ingredients.Length);
                Instantiate(ingredients[i], transform.position, transform.rotation);
                ingredientsSpawned++;
            }
            
        }
    }
}
