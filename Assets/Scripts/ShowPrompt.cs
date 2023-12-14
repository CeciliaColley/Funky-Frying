using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPrompt : MonoBehaviour
{
    [SerializeField] private GameObject prompt;

    private void Start()
    {
        if (prompt != null) { prompt.SetActive(false);}
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Actions_PlayerMovement playerMovementComponent = other.GetComponent<Actions_PlayerMovement>();

        if (playerMovementComponent != null)
        {
            if (prompt != null)
            {
                prompt.SetActive(true);
            }
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        _ = other.GetComponent<Actions_PlayerMovement>();
        if (prompt != null)
        {
            prompt.SetActive(false);
        }
    }
}
