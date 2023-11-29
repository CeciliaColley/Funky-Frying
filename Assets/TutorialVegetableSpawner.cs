using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialVegetableSpawner : MonoBehaviour
{
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
    [SerializeField] public int[] choppedCounts = new int[4] { 0, 0, 0, 0 }; /// [0] = tomato, [1] = basil, [2] = garlic, [3] = parmesan.
    [SerializeField] private int spawnTracker = 0;
    [SerializeField] private float spawnRate = 1.0f;

    void Start()
    {
        vegetables = new GameObject[] { tomato, basil, garlic, parmesan };
        garlicUI.SetActive(false);
        basilUI.SetActive(false);
        parmesanUI.SetActive(false);
        wellDone.SetActive(false);
        StartCoroutine(SpawnVegetableCoroutine());
    }

    void Update()
    { //TODO: TP2 - Fix - Clean code
      //TODO: TP2 - Could be a coroutine/Invoke: This was so hard omgggg
    }

    IEnumerator SpawnVegetableCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);

            if (choppedCounts[0] < 2 && choppedCounts[1] < 2 && choppedCounts[2] < 2 && choppedCounts[3] < 2)
            {
                SpawnVegetable();
            }
            else if (choppedCounts[0] >= 2 && choppedCounts[1] < 2 && choppedCounts[2] < 2 && choppedCounts[3] < 2)
            {
                SpawnVegetable();
                ToggleUI(basilUI);
                SwitchSpawnTracker(1);
            }
            else if (choppedCounts[0] >= 2 && choppedCounts[1] >= 2 && choppedCounts[2] < 2 && choppedCounts[3] < 2)
            {
                SpawnVegetable();
                ToggleUI(garlicUI);
                SwitchSpawnTracker(2);
            }
            else if (choppedCounts[0] >= 2 && choppedCounts[1] >= 2 && choppedCounts[2] >= 2 && choppedCounts[3] < 2)
            {
                SpawnVegetable();
                ToggleUI(parmesanUI);
                SwitchSpawnTracker(3);
            }
            else if (choppedCounts[0] >= 2 && choppedCounts[1] >= 2 && choppedCounts[2] >= 2 && choppedCounts[3] >= 2)
            {
                StaticManager.Instance.knowsPomodoro = true;
                wellDone.SetActive(true);
            }
            else
            {
                Debug.Log("TutorialVegetaleSpawner: the conditions to spawn a vegetable are not being met.");
            }
        }
    }

    void SpawnVegetable()
    {
        float i = Random.Range(-0.20f, -1.0f);
        Instantiate(vegetables[spawnTracker], new Vector3(transform.position.x, i, transform.position.z), transform.rotation);
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
