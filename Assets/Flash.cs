using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Flash : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] public float currentValue = 0;
    //TODO: Fix - Use summary (place 3 slashes ///) Instead of simple comment
    [SerializeField] private float saturateOrDesaturate = 1f; /// -1 for desaturate, +1 for saturate
    [SerializeField] private Color flashingColor;
    [SerializeField] private Color originalColor;
    [SerializeField] private float flashSpeed = 2f;
    [SerializeField] public bool isFlashing = false;

    private void Awake()
    {
        originalColor = spriteRenderer.color;
    }


    //TODO: TP2 - Syntax - Consistency in access modifiers (private/protected/public/etc)
    void Update()
    {
        if (isFlashing == true)
        {
            currentValue += Time.deltaTime * saturateOrDesaturate * flashSpeed;
            if (currentValue > 1)
            {
                saturateOrDesaturate = -1;
                currentValue = 1;
            }
            else if (currentValue < 0)
            {
                saturateOrDesaturate = 1;
                currentValue = 0;
            }

            spriteRenderer.color = Color.Lerp(originalColor, flashingColor, currentValue);
        }
    }
}
