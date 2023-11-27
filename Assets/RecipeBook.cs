using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeBook : MonoBehaviour
{
    public KitchenUI kitchenUI;

    private void OnMouseDown()
    {
        //TODO: TP2 - Fix - Clean code
        if (StaticManager.Instance.knowsPomodoro == false )
        {
            kitchenUI.MainPanel.SetActive(true);
            kitchenUI.LearnButton.SetActive(true);
            kitchenUI.CookButton.SetActive(false);
        } else if (StaticManager.Instance.knowsPomodoro == true)
        {
            kitchenUI.MainPanel.SetActive(true);
            kitchenUI.LearnButton.SetActive(true);
            kitchenUI.CookButton.SetActive(true);
        }


    }

}
