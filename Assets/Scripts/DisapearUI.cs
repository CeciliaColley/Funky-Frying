using System.Collections;
using UnityEngine;

public class DisappearingUI : MonoBehaviour
{
    [SerializeField] private CookingGameRules gameRules;
    [SerializeField] private GameObject buttonDisplay;

    private void Start()
    {
        // Start the coroutine to handle UI disappearance
        StartCoroutine(UIDisappears());
    }

    // Coroutine to make UI disappear when player's score reaches half of the beats in the song
    private IEnumerator UIDisappears()
    {
        if (gameRules != null)
        {
            yield return new WaitUntil(() => (gameRules.playerScore == gameRules.beatsInSong / 2));
        }

        if (buttonDisplay != null)
        {
            buttonDisplay.SetActive(false);
        }
    }
}
