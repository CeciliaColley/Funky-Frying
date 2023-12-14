using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;


public class RecipeBookBehaviour : MonoBehaviour
{
    [SerializeField] public KitchenUIManager kitchenUI;

    private void OnMouseDown()
    {
        OpenBook();
    }

    public void OpenBook()
    {
        if (kitchenUI != null)
        {
            if (StaticManager.Instance.lawyerIsDining == true)
            {
                kitchenUI.pastaEmptyButton.Select();
                if (!StaticManager.Instance.tutorialCompleted)
                {
                    kitchenUI.pastaMainMenu.SetActive(true);
                    kitchenUI.pastaLearnButton.SetActive(true);
                    kitchenUI.pastaCookButton.SetActive(false);
                }
                else
                {
                    kitchenUI.pastaMainMenu.SetActive(true);
                    kitchenUI.pastaLearnButton.SetActive(true);
                    kitchenUI.pastaCookButton.SetActive(true);
                }
            }
            else if (StaticManager.Instance.influencerIsDining == true)
            {
                kitchenUI.kaleEmptyButton.Select();
                kitchenUI.kaleRecipe.SetActive(true);
                kitchenUI.kaleCookButton.SetActive(true);

            }
            else { Debug.Log("In the RecipeScrpit, no character is dining."); }

        }
    }

}
