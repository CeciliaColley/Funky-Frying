using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LawyerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject Lawyer;
    [SerializeField] private AudioSource doorbell;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnLawyer());
    }

    IEnumerator SpawnLawyer()
    {
        if (!StaticManager.Instance.introVideoFinished && StaticManager.Instance.lawyerIsDining)
        {
            yield return new WaitUntil(() => StaticManager.Instance.introVideoFinished);
            yield return new WaitForSeconds(2.0f);
            doorbell.Play();
            Instantiate(Lawyer, transform.position, transform.rotation);
        }
        else if (StaticManager.Instance.lawyerIsDining)
        {
            Instantiate(Lawyer, transform.position, transform.rotation);
        }

    }
}
