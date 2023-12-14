using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PantryRatSpawner : MonoBehaviour
{
    [SerializeField] private PantryGameRules pantryLogic;
    [SerializeField] private float spawnInterval = 5.0f;
    [SerializeField] private GameObject rat;
    [SerializeField] private float ratHeight = 1f;
    [SerializeField] private float basketHeight = 1f;
    [SerializeField] private GameObject basket;
    [SerializeField] private float halfScreenHeight;
    [SerializeField] private float topLimit;
    [SerializeField] private float bottomLimit;
    [SerializeField] private float makeHalf = 2.0f;

    private void Start()
    {
        if (rat != null) { ratHeight = rat.GetComponent<Renderer>().bounds.size.x; }
        if (basket != null) { basketHeight = basket.GetComponent<Renderer>().bounds.size.y; }
        halfScreenHeight = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
        StartCoroutine(SpawnRats());
    }
    IEnumerator SpawnRats()
    {
        yield return new WaitUntil(() => pantryLogic.startGame);
        while (!pantryLogic.gameEnded)
        {
            yield return new WaitForSeconds(spawnInterval);

            // Use the rat's width to define a spawnRange, ensuring not to spawn on top of the basket.
            bottomLimit = - ( halfScreenHeight - basketHeight - (ratHeight / makeHalf));
            topLimit = halfScreenHeight - (ratHeight / makeHalf);
            float randomY = Random.Range(bottomLimit, topLimit);
            Vector3 spawnPosition = new(transform.position.x, randomY, transform.position.z);

            // Spawn the ingredient
            if (rat != null) { Instantiate(rat, spawnPosition, Quaternion.identity); }

        }
    }
}
