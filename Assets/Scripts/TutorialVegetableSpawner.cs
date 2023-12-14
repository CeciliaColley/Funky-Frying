using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialVegetableSpawner : MonoBehaviour
{
    //Referenced by TutorialHitZone
    public int[] choppedCounts = new int[4] { 0, 0, 0, 0 }; /// [0] = tomato, [1] = basil, [2] = garlic, [3] = parmesan.

    [SerializeField] private GameObject tomato;
    [SerializeField] private GameObject garlic;
    [SerializeField] private GameObject basil;
    [SerializeField] private GameObject parmesan;
    [SerializeField] private GameObject tomatoUI;
    [SerializeField] private GameObject garlicUI;
    [SerializeField] private GameObject basilUI;
    [SerializeField] private GameObject parmesanUI;
    [SerializeField] private GameObject wellDone;
    [SerializeField] private GameObject[] vegetables;
    [SerializeField] private int spawnTracker = 0;
    [SerializeField] private int succesfulCutsRequired = 2;
    [SerializeField] private float spawnRate = 1.0f;

    GameObject[] ingredientUI;

    void Start()
    {
        vegetables = new GameObject[] { tomato, basil, garlic, parmesan };
        ingredientUI = new GameObject[] { tomatoUI, basilUI, garlicUI, parmesanUI };
        garlicUI.SetActive(false);
        basilUI.SetActive(false);
        parmesanUI.SetActive(false);
        wellDone.SetActive(false);
        StartCoroutine(SpawnVegetableCoroutine());
    }
    IEnumerator SpawnVegetableCoroutine()
    {
        for (int i = 0; i < choppedCounts.Length; i++)
        {
            while (choppedCounts[i] < succesfulCutsRequired)
            {
                yield return new WaitForSeconds(spawnRate);
                SpawnVegetable();
                ToggleUI(ingredientUI[i]);
                SwitchSpawnTracker(i);
            }
        }

        wellDone.SetActive(true);
        StaticManager.Instance.tutorialCompleted = true;
    }

    void SpawnVegetable()
    {
        float i = Random.Range(-0.20f, -1.0f);
        if (vegetables != null) { Instantiate(vegetables[spawnTracker], new Vector3(transform.position.x, i, transform.position.z), transform.rotation); }
    }

    void ToggleUI(GameObject uiElement)
    {
        uiElement.SetActive(true);
    }

    void SwitchSpawnTracker(int newIndex)
    {
        spawnTracker = newIndex;
    }
}
