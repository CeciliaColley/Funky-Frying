using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Flash : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;
    public float CurrentValue = 0;
    //TODO: Fix - Use summary (place 3 slashes ///) Instead of simple comment
    public float SaturateOrDesaturate = 1f; // -1 for desaturate, +1 for saturate
    public Color FlashingColour;
    private Color OriginalColor;
    public float flashspeed = 2f;
    public bool isFlashing = false;

    private void Awake()
    {
        OriginalColor = SpriteRenderer.color;
    }


    //TODO: TP2 - Syntax - Consistency in access modifiers (private/protected/public/etc)
    // Update is called once per frame
    void Update()
    {
        if (isFlashing == true)
        {
            CurrentValue += Time.deltaTime * SaturateOrDesaturate * flashspeed;
            if (CurrentValue > 1)
            {
                SaturateOrDesaturate = -1;
                CurrentValue = 1;
            }
            else if (CurrentValue < 0)
            {
                SaturateOrDesaturate = 1;
                CurrentValue = 0;
            }

            SpriteRenderer.color = Color.Lerp(OriginalColor, FlashingColour, CurrentValue);
        }
    }
}
