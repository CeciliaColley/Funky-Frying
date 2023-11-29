using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetableSpawner : MonoBehaviour
{
    [SerializeField] private GameObject Tomato;
    [SerializeField] private GameObject Garlic;
    [SerializeField] private GameObject Basil;
    [SerializeField] private GameObject Parmesan;
    [SerializeField] private GameRules GameRules;
    [SerializeField] private float spawnRate;
    [SerializeField] private GameObject[] vegetables;
    [SerializeField] private int VegetablesSpawned = 0;

    void Start()
    {
        spawnRate = (float)60/GameRules.tempo;
        vegetables = new GameObject[] {Tomato, Garlic, Basil, Parmesan};
        StartCoroutine(SpawnVegetables());

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
        /*if (VegetablesSpawned < GameRules.beatsInSong)
        {
            if (Timer < spawnRate) // Count up to spawnrate...
            {
                Timer = Timer + Time.deltaTime;
            }
            else // ... then spawn a random vegetable from the array
            {
                int i = Random.Range(0, vegetables.Length);
                Instantiate(vegetables[i], transform.position, transform.rotation);
                Timer = 0;
                VegetablesSpawned++;
            }
        }*/
    }

    IEnumerator SpawnVegetables()
    {
        while (VegetablesSpawned < GameRules.beatsInSong)
        {
            yield return new WaitForSeconds(spawnRate);

            int i = Random.Range(0, vegetables.Length);
            Instantiate(vegetables[i], transform.position, transform.rotation);
            VegetablesSpawned++;
        }
    }
}
