using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeBook : MonoBehaviour
{
    public KitchenUI kitchenUI;

    private void OnMouseDown()
    {
        //TODO: TP2 - Fix - Clean code
        if (!StaticManager.Instance.knowsPomodoro)
        {
            kitchenUI.MainPanel.SetActive(true);
            kitchenUI.LearnButton.SetActive(true);
            kitchenUI.CookButton.SetActive(false);
        } else
        {
            kitchenUI.MainPanel.SetActive(true);
            kitchenUI.LearnButton.SetActive(true);
            kitchenUI.CookButton.SetActive(true);
        }


    }

}
