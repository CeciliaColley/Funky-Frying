using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LawyerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject lawyer;
    [SerializeField] private AudioSource doorbell;
    [SerializeField] private float customerSpawnDelay = 2.0f;

    void Start()
    {
        StartCoroutine(SpawnLawyer());
    }

    IEnumerator SpawnLawyer()
    {
        if (!StaticManager.Instance.introVideoFinished && StaticManager.Instance.lawyerIsDining)
        {
            yield return new WaitUntil(() => StaticManager.Instance.introVideoFinished);
            yield return new WaitForSeconds(customerSpawnDelay);
            if (doorbell != null) { doorbell.Play(); }
            if (lawyer != null) { Instantiate(lawyer, transform.position, transform.rotation); }
        }
        else if (StaticManager.Instance.lawyerIsDining && lawyer != null)
        {
            Instantiate(lawyer, transform.position, transform.rotation);
        }

    }
}
