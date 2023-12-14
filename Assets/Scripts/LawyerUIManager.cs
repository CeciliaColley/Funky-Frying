using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;
using UnityEngine.EventSystems;
using System.Linq;

public class LawyerUIManager : MonoBehaviour
{
    public bool clicked = false; // Referenced by Actions_FrontOfHouse and LawyerBehaviour
    public GameObject lawyerCanvas; //Referenced by LawyerBehaviour

    [SerializeField] private GeneralUIManager generalUIManager;
    [SerializeField] private GameObject ruggieroImage;
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private GameObject generalUIOverlay;
    [SerializeField] private GameObject annaImage;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button formalOption;
    [SerializeField] private Button informalOption;
    [SerializeField] private Button lastSelectedButton;
    [SerializeField] private Text dialogueText;
    [SerializeField] private LawyerBehaviour lawyer;
    [SerializeField] private Flash doorFlash;
    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private int servingDialogueTracker = 0;
    [SerializeField] private int perfectScore = 100;
    [SerializeField] private int greatScore = 90;
    [SerializeField] private int goodScore = 80;
    [SerializeField] private int okScore = 70;
    [SerializeField] private int firstTimeInteracting = 0;
    [SerializeField] private bool ruggierosTurn = true;
    [SerializeField] private bool clickedNext = false;
    [SerializeField] private string cloneName = "Lawyer(Clone)";
    [SerializeField] private int[] ruggieroDialogueLines;
    
    public string[] DialogueArray = {
    "I'm good, thank you. Could I get a pasta pomodoro please?",
    "Um... Well, actually, we don't have pasta pomodoro on the menu today.",
    "It's ok. I'll have a pasta carbonara then.",
    "Uhhh... We actually don't have pasta on the me-",
    "Ooooooooooooo!",
    "I'm so excited! I've been looking forward to this all week, I even canceled my 4:00 o'clock meeting!",
    "Ok... One pasta pomodoro coming right up!",
    };

    string[] DefaultDialogueArray = {
    "It smells really good in here.",
    "Boy am I hungry!",
    "It's not gonna take too long, is it?",
    "Pasta pasta I love pasta.",
    "Be generous with the Parm.",
    "Is it almost ready?",
    "Nice place you got here.",
    };

    public string[] perfectDialogue = {
    "That's exactly what I was craving!",
    "So are you from around here, mister...",
    "Ruggiero, and no. I live down by the railway but I work close by.",
    "Oh! What do you do?",
    "I'm a lawyer.",
    "Oh yeah? What kind of lawyer?",
    "The hungry kind!",
    "Heh, I'll let you get to it.",
    "Anna, that was delicious! You'll definitely be seeing more of me around here!",
    "Glad you enjoyed it."
    };

    public string[] greatDialogue = {
    "Oh! This looks amazing!",
    "Happy to serve you, mister...",
    "Ruggiero, and what did you say your name was?",
    "Anna. So, are you from around here?",
    "No. I live by the railroads, but I work close by.",
    "Really, whereabouts?",
    "Just at a boring old office type of place.",
    "How's the pasta?",
    "It was pretty good, I might be coming back.",
    "Glad you enjoyed it!"
    };

    public string[] goodDialogue = {
    "Huh, that's an interesting looking pasta pomodoro.",
    "Yeah... It's kinda my first day.",
    "Well, I'm not the kinda guy to waste food, so let's have it.",
    "Ha! I like that attitude, mister...",
    "Ruggiero. ... Hey, it's pretty tasty for a first try!",
    "Glad to hear it."
    };

    public string[] okDialogue = {
    "Is that a pasta pomodoro? It doesn't look like one.",
    "Yeah.. I got a little... Experimental!",
    "Hmmm, well, food is food I guess.",
    "So are you from around here?",
    "Is anyone? Hey, it wasn't terrible!"
    };

    void Start()
    {
        // Define which lines are ruggiero's.
        ruggieroDialogueLines = new int[] { 0, 2, 4, 5 };
        
        //Start with UI inactive
        generalUIManager = GameObject.FindObjectOfType<GeneralUIManager>();
        if (lawyerCanvas != null) { lawyerCanvas.SetActive(false); }
        if (optionsPanel != null) { optionsPanel.SetActive(false); }
        if (dialoguePanel != null) { dialoguePanel.SetActive(false); }
        eventSystem = EventSystem.current;

    }

    // Display appropriate dialogue based on the current state of the conversation and user interactions.
    // If the character has not been clicked and it's the first interaction, show greeting options and stop flashing.
    // If the character has been clicked and the dialogue tracker is within the valid range, display ordering dialogue.
    // If the character has not been clicked and the dialogue tracker exceeds the available dialogue options, show waiting dialogue.
    // If the character is currently serving, display serving-related dialogue.
    public void DisplayDialogue()
    {

        if (!StaticManager.Instance.isServing)
        {
            if ( !clicked && StaticManager.Instance.lawyerDialogueTracker == firstTimeInteracting) {  ShowGreetingOptions(); }
            else if (clicked && StaticManager.Instance.lawyerDialogueTracker <= DialogueArray.Length) { OrderingDialogue(); }
            else if (!clicked && StaticManager.Instance.lawyerDialogueTracker > DialogueArray.Length) { WaitingDialogue(); }
        }
        else
        {
            ServingDialogue();
        }
    }

    public void ShowGreetingOptions()
    {
        if (lawyerCanvas != null) {  lawyerCanvas.SetActive(true); }
        if (optionsPanel != null) { optionsPanel.SetActive(true); }
        if (dialoguePanel != null) { dialoguePanel.SetActive(false); }
        clicked = true;
        EventSystem.current.SetSelectedGameObject(null);
    }
    public void ChooseOption()
    {
        //Avoid double input when using controller and mouse at the same time. Ensure only one option is selected.
        if (EventSystem.current.currentSelectedGameObject.GetComponent<Button>() == formalOption &&
            EventSystem.current.currentSelectedGameObject.GetComponent<Button>() == informalOption)
        {
            EventSystem.current.SetSelectedGameObject(null);
        }
        else
        {
            if (optionsPanel != null) { Destroy(optionsPanel); }
            if (dialoguePanel != null) { dialoguePanel.SetActive(true); }
            DisplayDialogue();
        }
    }

    public void OrderingDialogue()
    {
        // Toggle appropriate UI, and select the appropriate button for control users
        if (generalUIOverlay != null) { generalUIOverlay.SetActive(false); }
        if (nextButton != null) { nextButton.Select(); }

        // Display the image of the character that coresponds to the dialogue line displayed
        if (ruggieroDialogueLines.Contains(StaticManager.Instance.lawyerDialogueTracker))
        {
            if (ruggieroImage != null) { ruggieroImage.SetActive(true); }
            if (annaImage != null) { annaImage.SetActive(false); }
        }
        else
        {
            if (ruggieroImage != null) { ruggieroImage.SetActive(false); }
            if (annaImage != null) { annaImage.SetActive(true); }
        }


        // Display lines of dialogue then close the UI, begin flashing the door, and keep track that the character has ordered.
        if (StaticManager.Instance.lawyerDialogueTracker < DialogueArray.Length)
        {
            if (dialogueText != null) { dialogueText.text = DialogueArray[StaticManager.Instance.lawyerDialogueTracker]; }
            StaticManager.Instance.lawyerDialogueTracker++;
        }
        else
        {
            CloseDialogueUI();
            if (doorFlash != null) { doorFlash.isFlashing = true; }
            StaticManager.Instance.hasOrdered = true;
            StaticManager.Instance.lawyerDialogueTracker++;
        }
    }

    public void CloseDialogueUI()
    {
        if (dialoguePanel != null) { dialoguePanel.SetActive(false); }
        if (generalUIOverlay != null) { generalUIOverlay.SetActive(true); }
        clicked = false;
    }

    public void WaitingDialogue()
    {
        Debug.Log("Waiting Dialogue");
        // Toggle aprropriate UI, and select the appropriate button for control users
        if (generalUIOverlay != null) { generalUIOverlay.SetActive(false); }
        if (lawyerCanvas != null) { lawyerCanvas.SetActive(true); }
        if (ruggieroImage != null) { ruggieroImage.SetActive(true); }
        if (annaImage != null) { annaImage.SetActive(false); }
        if (dialoguePanel != null) { dialoguePanel.SetActive(true); }
        if (nextButton != null) { nextButton.Select(); }

        // Display a random line from the characters default dialogue, when user clicks next, close the UI
        if (!clickedNext)
        {
            Debug.Log("Showing the line");
            int i = Random.Range(0, DefaultDialogueArray.Length);
            if (dialogueText != null) { dialogueText.text = DefaultDialogueArray[i]; }
            clickedNext = !clickedNext;
        }
        else { CloseDialogueUI(); clickedNext = !clickedNext; }
    }

    public void ServingDialogue()
    {
        // Toggle aprropriate UI, and select the appropriate button for control users
        if (nextButton != null) { nextButton.Select(); }
        if (lawyerCanvas != null) { lawyerCanvas.SetActive(true); }
        if (dialoguePanel != null) { dialoguePanel.SetActive(true); }
        if (optionsPanel != null) { optionsPanel.SetActive(true); }
        if (generalUIOverlay != null) { generalUIOverlay.SetActive(false); }        
        
        // Display serving dialogue based on player's score.
        if (StaticManager.Instance.lawyerIsDining == true)
        {
            if (StaticManager.Instance.playerScore >= perfectScore)
            {
                DetermineSpeaker();
                FollowConversation(perfectDialogue);
                RetireCustomer(perfectDialogue, cloneName);
            }
            else if (StaticManager.Instance.playerScore >= greatScore && StaticManager.Instance.playerScore < perfectScore)
            {
                DetermineSpeaker();
                FollowConversation(greatDialogue);
                RetireCustomer(greatDialogue, cloneName);

            }
            else if (StaticManager.Instance.playerScore >= goodScore && StaticManager.Instance.playerScore < greatScore)
            {
                DetermineSpeaker();
                FollowConversation(goodDialogue);
                RetireCustomer(goodDialogue, cloneName);
            }
            else if (StaticManager.Instance.playerScore >= okScore && StaticManager.Instance.playerScore < goodScore)
            {
                DetermineSpeaker();
                FollowConversation(okDialogue);
                RetireCustomer(okDialogue, cloneName);
            }
        }
    }

    public void DetermineSpeaker()
    {
        // Start with Ruggiero's image, as he has the first line, then switch back and forth between him and Anna.
        if (annaImage != null && ruggieroImage != null)
        {
            if (ruggierosTurn)
            {
                ruggieroImage.SetActive(true);
                annaImage.SetActive(false);
            }
            else if (!ruggierosTurn)
            {
                ruggieroImage.SetActive(false);
                annaImage.SetActive(true);
            }
            ruggierosTurn = !ruggierosTurn;
        }
    }

    
    public void FollowConversation(string[] Dialogue)
    {
        // Follow the serving conversation, based on the player's score, then close the UI
        if (servingDialogueTracker < Dialogue.Length)
        {
            if (dialogueText != null) { dialogueText.text = Dialogue[servingDialogueTracker]; }
        }
        else
        {
            StaticManager.Instance.lawyerDined = true;
            CloseDialogueUI();
        }
        servingDialogueTracker++;
    }

    // If the dialogue is over, destroy the customer and set their UI inactive.
    public void RetireCustomer(string[] Dialogue, string CloneName)
    {
        if (servingDialogueTracker > Dialogue.Length)
        {
            GameObject customer = GameObject.Find(CloneName);
            if (customer != null) { Destroy(customer); }
            if (lawyerCanvas != null ) { lawyerCanvas.SetActive(false); }
        }
    }

    // Select the informal greeting option for the player, if they are using a control. 
    // Method referenced by Actions_FrontOfHouse
    public void SelectFirstButton()
    {
        if (eventSystem.currentSelectedGameObject == null && informalOption != null)
        {
            informalOption.Select();
        }
    }
}