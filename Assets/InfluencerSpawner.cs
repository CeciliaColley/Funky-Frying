using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfluencerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject influencer;

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
            yield return new WaitForSeconds(3.0f);
            Instantiate(influencer);
        } else Instantiate(influencer);

    }
}
