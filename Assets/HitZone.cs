using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class HitZone : MonoBehaviour
{
    [SerializeField] private GameRules gameRules;
    [SerializeField] private SliceActions slice;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private string suffix = "(Clone)";
    [SerializeField] private string[] ingredientNames = { "Tomato", "Basil", "Garlic", "Parmesan" };
    [SerializeField] private Sprite[] choppedSprites = new Sprite[4];
    [SerializeField] private BoxCollider2D[] colliders = new BoxCollider2D[4];
    [SerializeField] private bool hasAddedScore = false;

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
                    gameRules.AddScore(gameRules.chopPoint);
                    spriteRenderer.sprite = choppedSprites[i];
                    Destroy(colliders[i]);
                }
            }
        }
    }


    void Start()
    {
        gameRules = GameObject.FindAnyObjectByType<GameRules>();
        slice = GameObject.FindAnyObjectByType<SliceActions>();
        spriteRenderer = GetComponentInParent<SpriteRenderer>();
    }

    private void Update()
    {
        if (StaticManager.Instance.automaticKill && !hasAddedScore)
        {
            if (transform.parent.position.x > StaticManager.Instance.deadZone / 4)
            {
                string VegetableName;
                VegetableName = transform.parent.name.Substring(0, (transform.parent.name.Length - suffix.Length));

                for (int i = 0; i < ingredientNames.Length; i++)
                {
                    if (VegetableName == ingredientNames[i])
                    {
                        gameRules.AddScore(gameRules.chopPoint);
                        spriteRenderer.sprite = choppedSprites[i];
                        Destroy(colliders[i]);
                        hasAddedScore = true;
                    }
                }
            }
        }
    }
}