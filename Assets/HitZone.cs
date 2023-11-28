using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class HitZone: MonoBehaviour
{
    [SerializeField] private GameRules gameRules;
    [SerializeField] private VegetableScript vegetable;
    [SerializeField] private SliceActions slice;
    [SerializeField] private BoxCollider2D tomatoCollider;
    [SerializeField] private BoxCollider2D garlicCollider;
    [SerializeField] private BoxCollider2D basilCollider;
    [SerializeField] private BoxCollider2D parmesanCollider;
    [SerializeField] private Sprite choppedTomatoSprite;
    [SerializeField] private Sprite choppedGarlicSprite;
    [SerializeField] private Sprite choppedBasilSprite;
    [SerializeField] private Sprite choppedParmesanSprite;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private string suffix = "(Clone)";
    [SerializeField] private string vegetableName1;
    [SerializeField] private string vegetableName2;
    [SerializeField] private string vegetableName3;
    [SerializeField] private string vegetableName4;

    private void OnTriggerEnter2D(Collider2D other)
    {
        string VegetableName;
        //TODO: TP2 - Fix - Hardcoded value/s - Serialize a suffix variable that has a default value = "(Clone)"
        VegetableName = transform.parent.name.Substring(0, (transform.parent.name.Length - suffix.Length));
        
        
            //TODO: TP2 - Fix - Hardcoded value/s
            if (VegetableName == vegetableName1)
            {
            Debug.Log("Tomato if");
            if (slice.ArrowPressed == SliceActions.InputOptions.up)
                {
                    gameRules.AddScore(gameRules.chopPoint);
                    spriteRenderer.sprite = choppedTomatoSprite;
                    Destroy(tomatoCollider);
                    Debug.Log("Tomato Chopped");
                }

            }
            if (VegetableName == vegetableName2)
            {
            Debug.Log("Basil if");
            if (slice.ArrowPressed == SliceActions.InputOptions.down)
                {
                    gameRules.AddScore(gameRules.chopPoint);
                    spriteRenderer.sprite = choppedBasilSprite;
                    Destroy(basilCollider);
                    Debug.Log("Basil Chopped");
                }
            }
            if (VegetableName == vegetableName3)
            {
            Debug.Log("Garlic if");
            if (slice.ArrowPressed == SliceActions.InputOptions.left)
                {
                    gameRules.AddScore(gameRules.chopPoint);
                    spriteRenderer.sprite = choppedGarlicSprite;
                    Destroy(garlicCollider);
                    Debug.Log("Garlic Chopped");
                }
            }
            if (VegetableName == vegetableName4)
            {
                Debug.Log("Parm if");
                if (slice.ArrowPressed == SliceActions.InputOptions.right)
                {
                    gameRules.AddScore(gameRules.chopPoint);
                    spriteRenderer.sprite = choppedParmesanSprite;
                    Destroy(parmesanCollider);
                    Debug.Log("Parm Chopped");
                }
            }
        
    }


    // Start is called before the first frame update
    void Start()
    {
        gameRules = GameObject.FindAnyObjectByType<GameRules>();
        slice = GameObject.FindAnyObjectByType<SliceActions>();
        vegetable = GameObject.FindAnyObjectByType<VegetableScript>();
        spriteRenderer = GetComponentInParent<SpriteRenderer>();
    }
}
