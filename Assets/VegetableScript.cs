using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class VegetableScript : MonoBehaviour
{
    void Update()
    {
        transform.position = transform.position + Vector3.right * StaticManager.Instance.speed * Time.deltaTime;

        //TODO: TP2 - Fix - OnBecameInvisible
        if (BecameInvisible()) { Destroy(gameObject);}
    }

    private bool BecameInvisible()
    {
        if (transform.position.x > StaticManager.Instance.deadZone)
        {
            return true;
        } else return false;
    }
}
