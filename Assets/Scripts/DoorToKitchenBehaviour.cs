using UnityEngine;

public class DoorToKitchenBehaviour : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void OnMouseDown()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.white;
        }
    }
}
