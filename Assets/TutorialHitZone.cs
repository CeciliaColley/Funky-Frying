using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialHitZone : MonoBehaviour
{
    [SerializeField] private TutorialVegetableSpawner TutorialVegetableSpawner;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private SliceActions slice;
    [SerializeField] private string suffix = "(Clone)";
    [SerializeField] private string[] ingredientNames = { "TutorialTomato", "TutorialBasil", "TutorialGarlic", "TutorialParmesan" };
    [SerializeField] private Sprite[] choppedSprites = new Sprite[4];
    [SerializeField] private BoxCollider2D[] colliders = new BoxCollider2D[4];

    private SliceActions.InputOptions GetCorrespondingInputOption(int index)
    {
        switch (index)
        {
            case 0:
                return SliceActions.InputOptions.up;
            case 1:
                return SliceActions.InputOptions.down;
            case 2:
                return SliceActions.InputOptions.left;
            case 3:
                return SliceActions.InputOptions.right;
            default:
                throw new ArgumentOutOfRangeException(nameof(index), "Invalid index for InputOptions");
        }
    }

    //TODO: TP2 - Fix - Repeated code
    private void OnTriggerEnter2D(Collider2D other)
    {
        string VegetableName;
        VegetableName = transform.parent.name.Substring(0, (transform.parent.name.Length - suffix.Length));

        for (int i = 0; i < ingredientNames.Length; i++)
        {
            if (VegetableName == ingredientNames[i])
            {
                if (slice.ArrowPressed == GetCorrespondingInputOption(i))
                {
                    TutorialVegetableSpawner.choppedCounts[i] = TutorialVegetableSpawner.choppedCounts[i] + 1;
                    spriteRenderer.sprite = choppedSprites[i];
                    Destroy(colliders[i]);
                }
            }
        }
    }

    void Start()
    {
        slice = GameObject.FindAnyObjectByType<SliceActions>();
        TutorialVegetableSpawner = GameObject.FindAnyObjectByType<TutorialVegetableSpawner>();
        spriteRenderer = GetComponentInParent<SpriteRenderer>();
    }
}