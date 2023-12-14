using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfluencerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject influencer;
    [SerializeField] private AudioSource doorbell;

    void Start()
    {
        StartCoroutine(SpawnInfluencer());
    }

    IEnumerator SpawnInfluencer()
    {
        // Wait until it's time for the influencer to dine, then spawn him.
        if (StaticManager.Instance.influencerIsDining == false)
        {
            yield return new WaitUntil(() => StaticManager.Instance.influencerIsDining);
            yield return new WaitForSeconds(2.0f);
            if (doorbell != null) { doorbell.Play(); }
            if (influencer != null) { Instantiate(influencer); }
        }
        else
        {
            if (influencer != null) { Instantiate(influencer); }
        }
    }
}
