using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeBook : MonoBehaviour
{
    [SerializeField] public KitchenUI kitchenUI;

    private void OnMouseDown()
    {
        if (kitchenUI != null)
        {
            //TODO: TP2 - Fix - Clean code
            if (StaticManager.Instance.lawyerIsDining == true)
            {
                if (!StaticManager.Instance.knowsPomodoro)
                {
                    kitchenUI.PastaMainPanel.SetActive(true);
                    kitchenUI.PastaLearnButton.SetActive(true);
                    kitchenUI.PastaCookButton.SetActive(false);
                }
                else
                {
                    kitchenUI.PastaMainPanel.SetActive(true);
                    kitchenUI.PastaMainPanel.SetActive(true);
                    kitchenUI.PastaMainPanel.SetActive(true);
                }
            } else if (StaticManager.Instance.influencerIsDining == true)
            {
                kitchenUI.KaleRecipe.SetActive(true);
                kitchenUI.KaleCookButton.SetActive(true);
                
            }

        }
    }

}
