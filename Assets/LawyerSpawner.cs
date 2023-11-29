using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LawyerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject Lawyer;
    // Start is called before the first frame update
    void Start()
    {
        if (StaticManager.Instance.lawyerIsDining == true)
        {
            Instantiate(Lawyer, transform.position, transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
