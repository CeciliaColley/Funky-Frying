using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatBehaviour : MonoBehaviour
{
    public int moveSpeed = 5; // Referenced by PantryCheats
    [SerializeField] private PantryGameRules pantryLogic;
    [SerializeField] private RatTrapBehaviour ratTrap;
    [SerializeField] private LossPoint lossPoint;
    [SerializeField] private int deadZone = -20;
    [SerializeField] private Actions_PantryCheats pantryCheats;

    private void Start()
    {
        pantryCheats = FindObjectOfType<Actions_PantryCheats>();
        pantryCheats.AddRatToList(this);
        pantryLogic = FindObjectOfType<PantryGameRules>();
        ratTrap = FindObjectOfType<RatTrapBehaviour>();
        lossPoint = FindObjectOfType<LossPoint>();
        StartCoroutine(DestroyWhenPastDeadZone());
    }
    void Update()
    {
        transform.position += moveSpeed * Time.deltaTime * Vector3.right;
    }

    IEnumerator DestroyWhenPastDeadZone()
    {
        yield return new WaitUntil(() => transform.position.x < deadZone);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (ratTrap != null)
        {
            if (other == ratTrap.GetComponent<Collider2D>()) { Destroy(gameObject); }
        }
        
        if (lossPoint != null)
        {
            if (other == lossPoint.GetComponent<PolygonCollider2D>()) { pantryLogic.AddEscapedRat(); }
        }
        
    }

    void OnDestroy()
    {
        if (pantryCheats != null) { pantryCheats.RemoveRatFromList(this); }
    }
}
