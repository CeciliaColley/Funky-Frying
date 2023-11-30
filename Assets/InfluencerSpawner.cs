using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfluencerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject influencer;
    [SerializeField] private AudioSource doorbell;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnInfluencer());
    }

    IEnumerator SpawnInfluencer()
    {
        if (StaticManager.Instance.influencerIsDining == false)
        {
            yield return new WaitUntil(() => StaticManager.Instance.influencerIsDining);
            yield return new WaitForSeconds(2.0f);
            doorbell.Play();
            StaticManager.Instance.isServing = false;
            Instantiate(influencer);
        } else Instantiate(influencer);

    }
}
