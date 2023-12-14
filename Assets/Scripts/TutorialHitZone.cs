using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialHitZone : MonoBehaviour
{
    [SerializeField] private TutorialVegetableSpawner tutorialVegetableSpawner;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Actions_Slice slice;
    [SerializeField] private string suffix = "(Clone)";
    [SerializeField] private string[] ingredientNames = { "TutorialTomato", "TutorialBasil", "TutorialGarlic", "TutorialParmesan" };
    [SerializeField] private Sprite[] choppedSprites = new Sprite[4];
    [SerializeField] private BoxCollider2D[] colliders = new BoxCollider2D[4];

    private Actions_Slice.InputOptions GetCorrespondingInputOption(int index)
    {
        return index switch
        {
            0 => Actions_Slice.InputOptions.up,
            1 => Actions_Slice.InputOptions.down,
            2 => Actions_Slice.InputOptions.left,
            3 => Actions_Slice.InputOptions.right,
            _ => throw new ArgumentOutOfRangeException(nameof(index), "Invalid index for InputOptions"),
        };
    }

    void Start()
    {
        slice = GameObject.FindAnyObjectByType<Actions_Slice>();
        tutorialVegetableSpawner = GameObject.FindAnyObjectByType<TutorialVegetableSpawner>();
        spriteRenderer = GetComponentInParent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        string VegetableName;
        VegetableName = transform.parent.name[..^suffix.Length];

        for (int i = 0; i < ingredientNames.Length; i++)
        {
            if (VegetableName == ingredientNames[i] && slice != null)
            {
                if (slice.ArrowPressed == GetCorrespondingInputOption(i))
                {
                    if (tutorialVegetableSpawner != null) { tutorialVegetableSpawner.choppedCounts[i]++; }
                    if (spriteRenderer != null) { spriteRenderer.sprite = choppedSprites[i]; }
                    if (colliders != null) { Destroy(colliders[i]); }
                }
            }
        }
    }
}