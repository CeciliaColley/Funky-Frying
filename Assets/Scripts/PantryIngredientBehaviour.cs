using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PantryIngredientBehaviour : MonoBehaviour
{
    public int moveSpeed = 5; // Referenced by PantryCheats
    public bool isGood; // Referenced by PantryCheats

    [SerializeField] private int deadZone = -20;
    [SerializeField] private char firstLetter = 'x';
    [SerializeField] private char firstLetterGood = 'G';
    [SerializeField] private char firstLetterBad = 'B';
    [SerializeField] private BasketBehaviour basket;
    [SerializeField] private LossPoint lossPoint;
    [SerializeField] private PantryGameRules pantryLogic;
    [SerializeField] private Actions_PantryCheats pantryCheats;



    void Start()
    {
        pantryCheats = FindObjectOfType<Actions_PantryCheats>();
        pantryCheats.AddIngredientToList(this);
        pantryLogic = FindObjectOfType<PantryGameRules>();
        basket = FindObjectOfType<BasketBehaviour>();
        lossPoint = FindObjectOfType<LossPoint>();
        
        StartCoroutine(DestroyWhenBelowDeadZone());
        
        char firstLetter = gameObject.name[0];
        
        if (firstLetter == firstLetterGood ) { isGood = true; } 
        else if (firstLetter == firstLetterBad) { isGood = false; }
    }

    IEnumerator DestroyWhenBelowDeadZone()
    {
        yield return new WaitUntil(() => transform.position.y < deadZone);
        Destroy(gameObject);
    }
    void Update()
    {
        transform.position += moveSpeed * Time.deltaTime * Vector3.down;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (basket != null && pantryLogic != null && other == basket.GetComponent<Collider2D>())
        {
            if (isGood)
            {
                pantryLogic.AddPoint();
                Destroy(gameObject);
            }
            else
            {
                pantryLogic.SubtractPoint();
                Destroy(gameObject);
            }
        }
        if (lossPoint != null && pantryLogic != null && other == lossPoint.GetComponent<PolygonCollider2D>())
        {
            if (isGood)
            {
                if (pantryLogic != null) { pantryLogic.SubtractPoint(); }
            }
        }
    }

    void OnDestroy()
    {
        if (pantryCheats != null ) { pantryCheats.RemoveIngredientFromList(this); }
    }
}
