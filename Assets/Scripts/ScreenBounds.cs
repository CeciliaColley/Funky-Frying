using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBounds : MonoBehaviour
{
    [SerializeField] private float playerWidth = 0.0f;
    [SerializeField] private float playerHeight = 0.0f;
    [SerializeField] private Vector2 screenBounds;
    [SerializeField] private int transformSign = -1;
    [SerializeField] private int half = 2;

    private void Start()
    {
        if (Camera.main != null) { screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z)); }
        playerWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / half;
        playerHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / half;
    }
    private void LateUpdate()
    {
        Vector3 ViewPosition = transform.position;
        ViewPosition.x = Mathf.Clamp(ViewPosition.x, screenBounds.x * transformSign + playerWidth, screenBounds.x);
        ViewPosition.y = Mathf.Clamp(ViewPosition.y, screenBounds.y * transformSign + playerHeight, screenBounds.y);
        transform.position = ViewPosition;
    }
}
