using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class HitZone: MonoBehaviour
{
    public GameRules GameRules; // Reference to GameRules script, assigned in start.
    public VegetableScript Vegetable; // Reference to the vegetable script, assigned in engine.
    public Slice Slice;
    public BoxCollider2D TomatoCollider;
    public BoxCollider2D GarlicCollider;
    public BoxCollider2D BasilCollider;
    public BoxCollider2D ParmesanCollider;
    public Sprite choppedTomatoSprite;
    public Sprite choppedGarlicSprite;
    public Sprite choppedBasilSprite;
    public Sprite choppedParmesanSprite;
    public SpriteRenderer SpriteRenderer;


    private void OnTriggerEnter2D(Collider2D other)
    {
        string VegetableName;
        //TODO: TP2 - Fix - Hardcoded value/s - Serialize a suffix variable that has a default value = "(Clone)"
        VegetableName = transform.parent.name.Substring(0, (transform.parent.name.Length - "(Clone)".Length));
        
        
            //TODO: TP2 - Fix - Hardcoded value/s
            if (VegetableName == "Tomato")
            {
                if (Slice.ArrowPressed == Slice.InputOptions.up)
                {
                    GameRules.AddScore(GameRules.PerfectScore);
                    SpriteRenderer.sprite = choppedTomatoSprite;
                    Destroy(TomatoCollider);
                }

            }
            if (VegetableName == "Basil")
            {
                if (Slice.ArrowPressed == Slice.InputOptions.down)
                {
                    GameRules.AddScore(GameRules.PerfectScore);
                    SpriteRenderer.sprite = choppedBasilSprite;
                    Destroy(BasilCollider);
                }
            }
            if (VegetableName == "Garlic")
            {
                if (Slice.ArrowPressed == Slice.InputOptions.left)
                {
                    GameRules.AddScore(GameRules.PerfectScore);
                    SpriteRenderer.sprite = choppedGarlicSprite;
                    Destroy(GarlicCollider);
                }
            }
            if (VegetableName == "Parmesan")
            {
                if (Slice.ArrowPressed == Slice.InputOptions.right)
                {
                    GameRules.AddScore(GameRules.PerfectScore);
                    SpriteRenderer.sprite = choppedParmesanSprite;
                    Destroy(ParmesanCollider);
                }
            }
        
    }


    // Start is called before the first frame update
    void Start()
    {
        GameRules = GameObject.FindAnyObjectByType<GameRules>(); // reference assigned in script because prefabs don't allow assignment in engine
        Slice = GameObject.FindAnyObjectByType<Slice>();
        Vegetable = GameObject.FindAnyObjectByType<VegetableScript>();
        SpriteRenderer = GetComponentInParent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
