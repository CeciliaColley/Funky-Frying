using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class DoorToFOHBehaviour : MonoBehaviour
{
    [SerializeField] private KitchenUIManager kitchenUI;
    [SerializeField] private GoToScene goToScene;
    [SerializeField] private string sceneToLoad = "FrontOfHouse";

    private void OnMouseDown()
    {
        if (kitchenUI.pastaMainMenu != null && kitchenUI.kaleRecipe != null && goToScene != null)
        {
            if (!kitchenUI.pastaMainMenu.activeSelf && !kitchenUI.kaleRecipe.activeSelf)
            {
                goToScene.OpenScene(sceneToLoad);
            }
        }
    }
}