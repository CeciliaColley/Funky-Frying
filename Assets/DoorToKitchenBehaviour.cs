using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

[System.Serializable]
public class DoorToKitchenBehaviour : MonoBehaviour
{
    [SerializeField] private GoToScene goToScene;
    [SerializeField] private string sceneToLoad = "Kitchen";
    [SerializeField] public Flash flash;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void OnMouseDown()
    {
        spriteRenderer.color = Color.white;
        if (StaticManager.Instance.hasOrdered == true )
        {
            //TODO: Fix - Hardcoded value - Serialize string to be able to reuse this script
            goToScene.OpenScene(sceneToLoad);
        }
    }

    private void Start()
    {
        goToScene = GameObject.FindAnyObjectByType<GoToScene>();
        flash = GetComponent<Flash>();
    }
}
