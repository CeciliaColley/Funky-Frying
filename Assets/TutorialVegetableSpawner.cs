using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialVegetableSpawner : MonoBehaviour
{
    public GameObject Tomato;
    public GameObject Garlic;
    public GameObject Basil;
    public GameObject Parmesan;
    public GameObject TomatoUI;
    public GameObject GarlicUI;
    public GameObject BasilUI;
    public GameObject ParmesanUI;
    public GameObject WellDone;
    GameObject[] vegetables;
    public int TomatoesChopped = 0;
    public int GarlicChopped = 0;
    public int BasilChopped = 0;
    public int ParmesanChopped = 0;
    private int spawnTracker = 0;
    private float Timer = 0;
    private float spawnRate = 1f;

    // Start is called before the first frame update
    void Start()
    {
        vegetables = new GameObject[] { Tomato, Garlic, Basil, Parmesan }; // initialize array with vegetables.
        TomatoUI.SetActive(false);
        GarlicUI.SetActive(false);
        BasilUI.SetActive(false);
        ParmesanUI.SetActive(false);
        WellDone.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (TomatoesChopped < 1 && GarlicChopped < 1 && BasilChopped < 1 && ParmesanChopped < 1) // If 3 tomatoes haven't been chopped
        {
            if (Timer < spawnRate) // Count up to spawnrate...
            {
                Timer = Timer + Time.deltaTime;
            }
            else // ... then spawn a tomato
            {
                TomatoUI.SetActive(true);
                Instantiate(vegetables[0], transform.position, transform.rotation);
                Timer = 0;
            }
        }

        else if (TomatoesChopped >= 1 && GarlicChopped < 1 && BasilChopped < 1 && ParmesanChopped < 1) // If 3 garlic haven't been chopped
        {
            if (Timer < spawnRate) // Count up to spawnrate...
            {
                Timer = Timer + Time.deltaTime;
            }
            else
            {
                GarlicUI.SetActive(true);
                Instantiate(vegetables[spawnTracker], transform.position, transform.rotation); //Spawn a garlic
                if (spawnTracker == 0)
                {
                    spawnTracker = 1;
                }
                else if (spawnTracker == 1)
                {
                    spawnTracker = 0;
                }
                Timer = 0;
            }
        }

        else if (TomatoesChopped >= 1 && GarlicChopped >= 1 && BasilChopped < 1 && ParmesanChopped < 1) // If 3 garlic haven't been chopped
        {
            if (Timer < spawnRate) // Count up to spawnrate...
            {
                Timer = Timer + Time.deltaTime;
            }
            else
            {
                BasilUI.SetActive(true);
                Instantiate(vegetables[spawnTracker], transform.position, transform.rotation); //Spawn a garlic
                if (spawnTracker == 0)
                {
                    spawnTracker = 1;
                }
                else if (spawnTracker == 1)
                {
                    spawnTracker = 2;
                }
                else if (spawnTracker == 2)
                {
                    spawnTracker = 0;
                }
                Timer = 0;
            }
        }

        else if (TomatoesChopped >= 1 && GarlicChopped >= 1 && BasilChopped >= 1 && ParmesanChopped < 1) // If 3 garlic haven't been chopped
        {
            if (Timer < spawnRate) // Count up to spawnrate...
            {
                Timer = Timer + Time.deltaTime;
            }
            else
            {
                ParmesanUI.SetActive(true);
                Instantiate(vegetables[spawnTracker], transform.position, transform.rotation); //Spawn a garlic
                if (spawnTracker == 0)
                {
                    spawnTracker = 1;
                }
                else if (spawnTracker == 1)
                {
                    spawnTracker = 2;
                }
                else if (spawnTracker == 2)
                {
                    spawnTracker = 3;
                }
                else if (spawnTracker == 3)
                {
                    spawnTracker = 0;
                }
                Timer = 0;
            }
        }

        else if (TomatoesChopped >= 1 && GarlicChopped >= 1 && BasilChopped >= 1 && ParmesanChopped >= 1)
        {
            StaticManager.Instance.knowsPomodoro = true;
            WellDone.SetActive(true);
        }
        
        else Debug.Log("0");
    }
}
