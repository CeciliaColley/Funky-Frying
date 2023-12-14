using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class KitchenIngredientBehaviour : MonoBehaviour
{   
    private void Update()
    {
        transform.position = transform.position + Vector3.right * StaticManager.Instance.speed * Time.deltaTime;

        if (OnBecomeInvisible()) { Destroy(gameObject);}

    }

    private bool OnBecomeInvisible()
    {
        if (transform.position.x > StaticManager.Instance.deadZone)
        {
            return true;
        }
        else return false;
    }
}
