using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialHitZone : MonoBehaviour
{
    public TutorialVegetableSpawner TutorialVegetableSpawner;
    public SliceActions Slice;
    public BoxCollider2D TutorialTomatoCollider;
    public BoxCollider2D TutorialGarlicCollider;
    public BoxCollider2D TutorialBasilCollider;
    public BoxCollider2D TutorialParmesanCollider;
    public Sprite choppedTomatoSprite;
    public Sprite choppedGarlicSprite;
    public Sprite choppedBasilSprite;
    public Sprite choppedParmesanSprite;
    public SpriteRenderer SpriteRenderer;


    private void OnTriggerEnter2D(Collider2D other)
    {
        //TODO: TP2 - Fix - Repeated code
        string VegetableName;
        VegetableName = transform.parent.name.Substring(0, (transform.parent.name.Length - "(Clone)".Length));


        if (VegetableName == "TutorialTomato")
        {
            if (Slice.ArrowPressed == SliceActions.InputOptions.up)
            {
                TutorialVegetableSpawner.TomatoesChopped = TutorialVegetableSpawner.TomatoesChopped +1;
                SpriteRenderer.sprite = choppedTomatoSprite;
                Destroy(TutorialTomatoCollider);
            }

        }
        if (VegetableName == "TutorialBasil")
        {
            if (Slice.ArrowPressed == SliceActions.InputOptions.down)
            {
                TutorialVegetableSpawner.BasilChopped = TutorialVegetableSpawner.BasilChopped + 1;
                SpriteRenderer.sprite = choppedBasilSprite;
                Destroy(TutorialBasilCollider);
            }
        }
        if (VegetableName == "TutorialGarlic")
        {
            if (Slice.ArrowPressed == SliceActions.InputOptions.left)
            {
                TutorialVegetableSpawner.GarlicChopped = TutorialVegetableSpawner.GarlicChopped + 1;
                SpriteRenderer.sprite = choppedGarlicSprite;
                Destroy(TutorialGarlicCollider);
            }
        }
        if (VegetableName == "TutorialParmesan")
        {
            if (Slice.ArrowPressed == SliceActions.InputOptions.right)
            {
                TutorialVegetableSpawner.ParmesanChopped = TutorialVegetableSpawner.ParmesanChopped + 1;
                SpriteRenderer.sprite = choppedParmesanSprite;
                Destroy(TutorialParmesanCollider);
            }
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        Slice = GameObject.FindAnyObjectByType<SliceActions>();
        TutorialVegetableSpawner = GameObject.FindAnyObjectByType<TutorialVegetableSpawner>();
        SpriteRenderer = GetComponentInParent<SpriteRenderer>();
    }
}
