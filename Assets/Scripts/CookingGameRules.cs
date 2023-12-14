using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

[System.Serializable]
public class CookingGameRules : MonoBehaviour
{
    public int playerScore = 0; // Referenced in Actions_CookingCheats, DisapearUI, and IngredientSpawner
    public int chopPoint = 1; // Referenced in HitZone
    public int tempo = 118; // Value in beats per minute. Referenced in IngredientSpawner
    public int beatsInSong = 164; // Referenced in Actions_CookingCheats, Disapear UI, Ingredient Spawner,and GameRules. 
    public float audioLength = 0.0f; // Referenced in Actions_CookingCheats and GameRules

    [SerializeField] private float scoreToCoinConversionRate = 0.1f;
    [SerializeField] private int percentage = 0;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text percentageString;
    [SerializeField] private GameObject scorePanel;
    [SerializeField] private GameObject perfect;
    [SerializeField] private GameObject great;
    [SerializeField] private GameObject good;
    [SerializeField] private GameObject ok;
    [SerializeField] private GameObject cantServe;
    [SerializeField] private GameObject serve;
    [SerializeField] private AudioSource music;

    private const int PerfectScoreThreshold = 100;
    private const int GreatScoreThreshold = 90;
    private const int GoodScoreThreshold = 80;
    private const int OkScoreThreshold = 70;

    private const float PerfectExperienceGain = 1.0f;
    private const float GreatExperienceGain = 0.75f;
    private const float GoodExperienceGain = 0.5f;
    private const float OkExperienceGain = 0.3f;

    private void Start()
    {
        // Deactivate scorePanel at the start
        if (scorePanel != null) { scorePanel.SetActive(false); }
        // Get the length of the audio clip for later use
        if (music != null) { audioLength = music.clip.length; }
        // Start the coroutine to check the music end
        StartCoroutine(OnMusicEnd());
    }

    private IEnumerator OnMusicEnd()
    {
        yield return new WaitUntil(() => music != null && music.time >= audioLength);

        // Calculate player's score and save it across scenes
        percentage = playerScore * 100 / beatsInSong;
        StaticManager.Instance.playerScore = percentage;

        // Manage UI and display score to screen
        if (percentageString != null) { percentageString.text = percentage.ToString() + "%"; }
        if (scorePanel != null) { scorePanel.SetActive(true); }
        if (perfect != null) { perfect.SetActive(false); }
        if (great != null) { great.SetActive(false); }
        if (good != null) { good.SetActive(false); }
        if (ok != null) { ok.SetActive(false); }
        if (cantServe != null) { cantServe.SetActive(false); }

        // Determine the score level and update the experience and serving status
        UpdateScoreUI();

        // Calculate the money earned based on the percentage, conversion rate, and experience
        float rawMoney = percentage * scoreToCoinConversionRate * StaticManager.Instance.experience;
        StaticManager.Instance.pendingCoins = Mathf.CeilToInt(rawMoney);
        StaticManager.Instance.pantryDirtiness++;
    }

    // Display the UI that corresponds to the player's score and add experience accordingly
    private void UpdateScoreUI()
    {
        if (percentage == PerfectScoreThreshold)
        {
            SetUIScoreLevel(perfect, PerfectExperienceGain);
        }
        else if (percentage >= GreatScoreThreshold)
        {
            SetUIScoreLevel(great, GreatExperienceGain);
        }
        else if (percentage >= GoodScoreThreshold)
        {
            SetUIScoreLevel(good, GoodExperienceGain);
        }
        else if (percentage >= OkScoreThreshold)
        {
            SetUIScoreLevel(ok, OkExperienceGain);
        }
        else if (percentage < OkScoreThreshold && cantServe != null && serve != null)
        {
            cantServe.SetActive(true);
            serve.SetActive(false);
        }
    }

    private void SetUIScoreLevel(GameObject uiElement, float experienceGain)
    {
        if (uiElement != null)
        {
            uiElement.SetActive(true);
            StaticManager.Instance.isServing = true;
            StaticManager.Instance.experience += experienceGain;
        }
    }

    // Method to add score, referenced by ChopLogic
    public void AddScore(int score)
    {
        playerScore += score;
        if (scoreText != null) { scoreText.text = playerScore.ToString(); }
    }
}
