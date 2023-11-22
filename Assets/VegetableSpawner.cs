using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetableSpawner : MonoBehaviour
{
    public GameObject Tomato;
    public GameObject Garlic;
    public GameObject Basil;
    public GameObject Parmesan;
    public GameRules GameRules;
    private float Timer = 0;
    private float spawnRate;
    GameObject[] vegetables;
    public int VegetablesSpawned = 0;


    // Start is called before the first frame update
    void Start()
    {
        spawnRate = (float)60/GameRules.tempo; // find how many seconds must be between each vegetable chop.
        
        vegetables = new GameObject[] {Tomato, Garlic, Basil, Parmesan}; // initialize array with vegetables.
        
        //TODO: TP1 - Unused method/variable - Why is this in multiple scripts?
        System.Random randomNumber = new System.Random(); // Initialize random number
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: TP2 - Fix - Clean code
        if (VegetablesSpawned < ((15*GameRules.BeatsInSong)/100))
        {
            //TODO: TP2 - Could be a coroutine/Invoke
            if (Timer < spawnRate) // Count up to spawnrate...
            {
                Timer = Timer + Time.deltaTime;
            }
            else // ... then spawn a random vegetable from the array
            {
                int i = Random.Range(0, ((25*vegetables.Length)/100));
                Instantiate(vegetables[i], transform.position, transform.rotation);
                Timer = 0;
                VegetablesSpawned++;
            }
        }
        if ( VegetablesSpawned >= ((15 * GameRules.BeatsInSong) / 100) && VegetablesSpawned < ((30 * GameRules.BeatsInSong) / 100))
        {
            if (Timer < spawnRate) // Count up to spawnrate...
            {
                Timer = Timer + Time.deltaTime;
            }
            else // ... then spawn a random vegetable from the array
            {
                int i = Random.Range(0, ((50 * vegetables.Length) / 100));
                Instantiate(vegetables[i], transform.position, transform.rotation);
                Timer = 0;
                VegetablesSpawned++;
            }
        }
        if (VegetablesSpawned >= ((30 * GameRules.BeatsInSong) / 100) && VegetablesSpawned < ((45 * GameRules.BeatsInSong) / 100))
        {
            if (Timer < spawnRate) // Count up to spawnrate...
            {
                Timer = Timer + Time.deltaTime;
            }
            else // ... then spawn a random vegetable from the array
            {
                int i = Random.Range(0, ((75 * vegetables.Length) / 100));
                Instantiate(vegetables[i], transform.position, transform.rotation);
                Timer = 0;
                VegetablesSpawned++;
            }
        }
        if (VegetablesSpawned >= ((45 * GameRules.BeatsInSong) / 100) && VegetablesSpawned < GameRules.BeatsInSong)
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
        }

    }
}
