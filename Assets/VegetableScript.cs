using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class VegetableScript : MonoBehaviour
{
    public bool isChopped = false;

   
    // Update is called once per frame
    void Update()
    {
        //Moves the vegetable according to the speed set in GameRules, and destroys the vegetable offscreen.
        transform.position = transform.position + Vector3.right * StaticManager.Instance.speed * Time.deltaTime;

        //TODO: TP2 - Fix - OnBecameInvisible
        if (transform.position.x > StaticManager.Instance.deadZone)
        {
            Destroy(gameObject);
        }

    }
}
