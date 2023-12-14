using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralUIManager : MonoBehaviour
{
    public bool showClipboard = false; // Referenced in InfluencerBehaviour 

    [SerializeField] private GameObject openClipboard;
    [SerializeField] private GameObject coinsDisplay;
    [SerializeField] private Button menuButton;
    [SerializeField] private Button emptyButton;
    [SerializeField] private Button cleanPantry;
    [SerializeField] private GameObject closedClipboard;
    [SerializeField] private GameObject defaultToDo;
    [SerializeField] private GameObject influencerToDo;
    [SerializeField] private GameObject lawyerToDo;
    [SerializeField] private GameObject influencerToDoDone;
    [SerializeField] private GameObject lawyerToDoDone;
    [SerializeField] private GameObject cleanPantryToDo;
    [SerializeField] private Flash flash;
    [SerializeField] private AudioSource cashSound;
    [SerializeField] private Text coinsUI;

    private void Start()
    {
        // Hide defaultToDo if lawyer and influencer have dined
        if (StaticManager.Instance.lawyerDined && StaticManager.Instance.influencerDined && defaultToDo != null) { defaultToDo.SetActive(false); }
        // Start with clipboard closed
        if (openClipboard != null) { openClipboard.SetActive(false); }

        if  (!StaticManager.Instance.introVideoFinished)
        {
            if (closedClipboard != null) { closedClipboard.SetActive(false); }
            if (menuButton != null) { menuButton.gameObject.SetActive(false); }
            if (coinsDisplay != null) { coinsDisplay.SetActive(false); }
            StartCoroutine(LoadUI());
        }

        StartCoroutine(ShowCleanPantryTask());
        StartCoroutine(ShowKaleTask());
        StartCoroutine(ShowPastaTask());
        StartCoroutine(UpdateCoinDisplay());
    }

    public void OpenClipboard() // Referenced in Actions Front of House
    {
        // Toggle the showClipboard flag that determines whether the clipboard is open or not.
        showClipboard = !showClipboard;
        StartCoroutine(CheckForClipboard());
    }

    private IEnumerator CheckForClipboard()
    {
        if (showClipboard)
        {
            // Show openClipboard, hide menuButton, hide closedClipboard, stop flashing
            if (emptyButton != null) emptyButton.Select();
            if (openClipboard != null) openClipboard.SetActive(true);
            if (menuButton != null) menuButton.gameObject.SetActive(false);
            if (closedClipboard != null) closedClipboard.SetActive(false);
            if (flash != null) flash.isFlashing = false;
        }
        else
        {
            // Hide openClipboard, show closedClipboard, show menuButton
            if (openClipboard != null) openClipboard.SetActive(false);
            if (closedClipboard != null) closedClipboard.SetActive(true);
            if (menuButton != null) menuButton.gameObject.SetActive(true);
        }
        yield return null;
    }

    // Wait until pantry dirtiness reaches 2 to show clean pantry task
    private IEnumerator ShowCleanPantryTask()
    {
        if (cleanPantryToDo != null) cleanPantryToDo.SetActive(false);
        yield return new WaitUntil(() => StaticManager.Instance != null && StaticManager.Instance.pantryDirtiness >= 2);
        if (cleanPantryToDo != null) cleanPantryToDo.SetActive(true);
        if (defaultToDo != null) defaultToDo.SetActive(false);
        if (flash != null) flash.isFlashing = true;
    }

    // If lawyer hasn't dined, wait for order and show task on clipboard
    private IEnumerator ShowPastaTask()
    {
        if (lawyerToDo != null) lawyerToDo.SetActive(false);
        if (lawyerToDoDone != null) lawyerToDoDone.SetActive(false);

        if (!StaticManager.Instance.lawyerDined)
        {
            yield return new WaitUntil(() => StaticManager.Instance.hasOrdered && StaticManager.Instance.lawyerIsDining);

            if (lawyerToDo != null) lawyerToDo.SetActive(true);
            if (defaultToDo != null) defaultToDo.SetActive(false);
        }

        yield return new WaitUntil(() => StaticManager.Instance.lawyerDined);

        if (lawyerToDo != null) lawyerToDo.SetActive(false);
        if (lawyerToDoDone != null) lawyerToDoDone.SetActive(true);
        yield break;
    }

    // If influencer hasn't dined, wait for order and show task on clipboard
    private IEnumerator ShowKaleTask()
    {
        if (influencerToDoDone != null) influencerToDoDone.SetActive(false);
        if (influencerToDo != null) influencerToDo.SetActive(false);

        if (!StaticManager.Instance.influencerDined)
        {
            yield return new WaitUntil(() => StaticManager.Instance.hasOrdered && StaticManager.Instance.influencerIsDining);

            if (influencerToDo != null) influencerToDo.SetActive(true);
            if (defaultToDo != null) defaultToDo.SetActive(false);
        }

        yield return new WaitUntil(() => StaticManager.Instance.influencerDined);

        if (influencerToDo != null) influencerToDo.SetActive(false);
        if (influencerToDoDone != null) influencerToDoDone.SetActive(true);
        yield break;
    }


    private IEnumerator UpdateCoinDisplay()
    {
        if (coinsUI != null) coinsUI.text = (StaticManager.Instance.playerMoney).ToString();
        // If there are pending coins and player is serving, wait until serving is done to add pending coins to player's money
        if (StaticManager.Instance.pendingCoins > 0 && StaticManager.Instance.isServing)
        {
            yield return new WaitUntil(() => !StaticManager.Instance.isServing);

            if (cashSound != null) cashSound.Play();

            if (coinsUI != null)
            {
                coinsUI.text = (StaticManager.Instance.playerMoney + StaticManager.Instance.pendingCoins).ToString();
            }

            StaticManager.Instance.playerMoney += StaticManager.Instance.pendingCoins;
            StaticManager.Instance.pendingCoins = 0;
        }
    }

    IEnumerator LoadUI()
    {
        yield return new WaitUntil(() => StaticManager.Instance.introVideoFinished);
        if (closedClipboard != null) { closedClipboard.SetActive(true); }
        if (menuButton != null) { menuButton.gameObject.SetActive(true); }
        if (coinsDisplay != null) { coinsDisplay.SetActive(true); }
    }
}
