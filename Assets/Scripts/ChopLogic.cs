using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;


[System.Serializable]
public class ChopLogic : MonoBehaviour
{
    [SerializeField] private Actions_CookingCheats cookingCheats;
    [SerializeField] private CookingGameRules gameRules;
    [SerializeField] private Actions_Slice slice;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] choppedSprites = new Sprite[4];
    [SerializeField] private BoxCollider2D[] colliders = new BoxCollider2D[4];
    [SerializeField] private string suffix = "(Clone)";
    [SerializeField] private string[] ingredientNames = { "Tomato", "Basil", "Garlic", "Parmesan" };
    [SerializeField] private bool hasAddedScore = false;

    void Start()
    {
        // Find instances of other scripts in the scene
        gameRules = FindObjectOfType<CookingGameRules>();
        cookingCheats = FindObjectOfType<Actions_CookingCheats>();
        slice = GameObject.FindObjectOfType<Actions_Slice>();
        spriteRenderer = GetComponentInParent<SpriteRenderer>();

        // Start the coroutine for automatic kill
        StartCoroutine(AutomaticKill());
    }

    /* 
    When a collision occurs, check if the collision was effected with the correct key by determining the ingredients name and 
    finding it's corresponding input action. If both conditions are met, chop the ingredient and destroy associated collider.
    */
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (ingredientNames != null)
        {
            for (int i = 0; i < ingredientNames.Length; i++)
            {
                if (DetermineIngredientName(suffix) == ingredientNames[i] && slice.ArrowPressed == GetCorrespondingInputOption(i))
                {
                    ChopIngredient(i);
                    Destroy(colliders[i]);
                }
            }
        }
    }

    //When a cheating, chop the ingredient and destroy associated collider.
    private IEnumerator AutomaticKill()
    {
        if (cookingCheats != null )
        {
            yield return new WaitUntil(() => cookingCheats.automaticKill);
            yield return new WaitUntil(() => (transform.parent.position.x > slice.transform.position.x));
            if (ingredientNames != null)
            {
                for (int i = 0; i < ingredientNames.Length; i++)
                {
                    if (DetermineIngredientName(suffix) == ingredientNames[i])
                    {
                        ChopIngredient(i);
                        yield break;
                    }
                }
            } 
        }
    }

    // Map index to corresponding InputOptions enum
    private Actions_Slice.InputOptions GetCorrespondingInputOption(int index)
    {
        return index switch
        {
            0 => Actions_Slice.InputOptions.up,
            1 => Actions_Slice.InputOptions.down,
            2 => Actions_Slice.InputOptions.left,
            3 => Actions_Slice.InputOptions.right,
            _ => throw new System.ArgumentOutOfRangeException(nameof(index), "Invalid index for InputOptions"),
        };
    }

    // Extract the ingredient name from the parent's name, removing the suffix
    private string DetermineIngredientName(string suffix)
    {
        string vegetableName = transform.parent.name;
        if (vegetableName.EndsWith(suffix))
        {
            vegetableName = vegetableName[..^suffix.Length];
        }
        return vegetableName;
    }

    // Update the score and change the sprite when an ingredient is chopped
    private void ChopIngredient(int ingredientIndex)
    {
        if (gameRules != null && spriteRenderer != null)
        {
            gameRules.AddScore(gameRules.chopPoint);
            spriteRenderer.sprite = choppedSprites[ingredientIndex];
        }
    }
}