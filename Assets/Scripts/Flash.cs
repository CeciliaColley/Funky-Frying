using UnityEngine;
using UnityEngine.UI;

public class Flash : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Image image;
    [SerializeField] private float currentValue = 0.0f;
    [SerializeField] private float flashSpeed = 2f;
    [SerializeField] private float saturateOrDesaturate = 1f; /// -1 for desaturation, +1 for saturation
    [SerializeField] private float desaturate = -1.0f;
    [SerializeField] private float saturate = 1.0f;
    [SerializeField] private float neutral = 0.0f;
    [SerializeField] private Color flashingColor;
    [SerializeField] private Color originalColor;
    public bool isFlashing = false;

    private void Awake()
    {
        if (spriteRenderer != null) { originalColor = spriteRenderer.color; }
        else if (image != null) { originalColor = image.color; }
    }
    private void Update()
    {
        if (isFlashing)
        {
            currentValue += Time.deltaTime * saturateOrDesaturate * flashSpeed;

            if (currentValue > saturate)
            {
                saturateOrDesaturate = desaturate;
                currentValue = saturate;
            }
            else if (currentValue < neutral)
            {
                saturateOrDesaturate = saturate;
                currentValue = neutral;
            }

            if (spriteRenderer != null){ spriteRenderer.color = Color.Lerp(originalColor, flashingColor, currentValue);}
            else if (image != null) { image.color = Color.Lerp(originalColor, flashingColor, currentValue); }
        }
    }
}