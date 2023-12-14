using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;

public class InfluencerUIManager : MonoBehaviour
{
    public GameObject influencerCanvas; // Referenced in InfluencerBehaviour

    [SerializeField] private GameObject generalUIOverlay;
    [SerializeField] private GameObject simonImage;
    [SerializeField] private GameObject annaImage;
    [SerializeField] private Text dialogueText;
    [SerializeField] private Button nextButton;
    [SerializeField] private int speakerTracker = 0;
    [SerializeField] private int servingDialogueTracker = 0;
    [SerializeField] private int longLineFontSize = 32;
    [SerializeField] private int fontSize = 40; 
    [SerializeField] private int perfectScore = 100;
    [SerializeField] private int greatScore = 90;
    [SerializeField] private int goodScore = 80;
    [SerializeField] private int okScore = 70;
    [SerializeField] private string cloneName = "Influencer(Clone)";
    [SerializeField] private bool simonsTurn = true;
    [SerializeField] private bool clickedNext = false;
    [SerializeField] private int[] longLines;


    public string[] DialogueArray = {
    "Well howdy there!",
    "Hi! I'm Anna and I'll be your server today.",
    "Hi Anna. I'd introduce myself, but I'm pretty sure you already know who I am.",
    "I uh-",
    "5 million subscribers on imbetterthanu.com! Yeah, baby, LET'S GOOOOOOOOO",
    "Oh, uh",
    "Alright, listen up: I want a meticulously handcrafted, gluten-free, organic, non-GMO, artisanal kale salad, but only if the kale has been serenaded by a choir of organic, free-range chickens for at least 30 minutes. Hold the onion.",
    "...",
    "Dress it in a vinaigrette made from the tears of a single sustainably-harvested olive, and sprinkle it with Himalayan salt that has been blessed by a certified yoga instructor.",
    "*Sigh*"
};

    public string[] DefaultDialogueArray = {
    "Finally, someone who understands the importance of my presence.",
    "Anna, sweetheart, if you want a picture just ask.",
    "I'd introduce myself, but I'm pretty sure you've Googled me already.",
    "What's taking so long? I have a schedule tighter than your budget wine list.",
    "5 million subscribers on imbetterthanu.com! It's not bragging if it's true.",
    "Let's speed this up. I have more important things to do than wait.",
    "...",
    "If my kale isn't serenaded by the end of this, heads will roll. Figuratively, of course.",
    };

    public string[] perfectDialogue = {
    "Finally! Someone who understands my sophisticated palate!",
    "... So, what brings you here today?",
    "Oh, I only dine at places with a certain ambiance, you know, upscale and refined.",
    "Yes yes, very upscale.",
    "Also, I'm trying to keep a healthy diet. Can't dissapoint the lady subscribers, you know?",
    "...",
    "So Anna, baby, I'll be leaving a glowing review! The exposure should cover the bill?",
    "Uh, actually-",
    "Great! Thanks!"
};

    public string[] greatDialogue = {
    "Impressive. This kale salad has potential, Anna.",
    "... So, what brings you here today?",
    "Oh, I only dine at places with a certain ambiance, you know, upscale and refined.",
    "Yes yes, very upscale.",
    "Are you just gonna stand there and watch me eat?",
    "...",
    "So Anna, baby, I'll be leaving a glowing review! The exposure should cover the bill?",
    "Uh, actually-",
    "Great! Thanks!"
};

    public string[] goodDialogue = {
    "Hmm, interesting take on the kale salad, Anna.",
    "... So, what brings you here today?",
    "Just getting some content.",
    "You film around here?",
    "Yeah. Are you just gonna stand there and watch me eat?",
    "...",
    "So Anna, baby, I'll be leaving a glowing review! The exposure should cover the bill?",
    "Uh, actually-",
    "Great! Thanks!"
};

    public string[] okDialogue = {
    "Not terrible, Anna. I've had worse. Maybe my followers will find it amusing.",
    "Your followers enjoy culinary adventures, then?",
    "Yeah- Wait, are you not subscribed!?",
    "...",
    "Whatever. The exposure should cover the bill.",
    "Uh, actually-",
    "Thanks for the ''salad''"
};

    void Start()
    {
        // Define which lines are Simonn's.
        longLines = new int[] { 6, 8 };

        //Start with UI inactive
        if (influencerCanvas != null) { influencerCanvas.SetActive(false); }

    }

   // Display appropriate dialogue based on the current state of the conversation and user interactions.
   // If not serving determine whether to display order-related dialogues or waiting dialogues.
   // If serving, it displays dialogues related to the serving state.
    public void DisplayDialogue()
    {
        if (!StaticManager.Instance.isServing)
        {
            if (StaticManager.Instance.influencerDialogueTracker <= DialogueArray.Length) { OrderDialogue(); }
            else if (StaticManager.Instance.influencerDialogueTracker > DialogueArray.Length) { WaitingDialogue(); }
        }
        else
        {
            ServingDialogue();
        }
    }

    public void OrderDialogue()
    {
        // Display the image of the character that coresponds to the dialogue line displayed
        DetermineSpeaker();

        // Toggle appropriate UI, and select the appropriate button for control users
        if (generalUIOverlay != null) { generalUIOverlay.SetActive(false); }
        if ( influencerCanvas != null ) { influencerCanvas.SetActive(true); }
        if (nextButton != null) { nextButton.Select(); }

        // Display lines of dialogue then close the UI and keep track that the character has ordered.
        if (StaticManager.Instance.influencerDialogueTracker < DialogueArray.Length)
        {
            if (longLines.Contains(StaticManager.Instance.influencerDialogueTracker))
            {
                if (dialogueText != null) { dialogueText.fontSize = longLineFontSize; }
            }
            else if (dialogueText != null) { dialogueText.fontSize = fontSize; }

            if (dialogueText != null) { dialogueText.text = DialogueArray[StaticManager.Instance.influencerDialogueTracker]; }
            StaticManager.Instance.influencerDialogueTracker++;
        }
        else
        {
            CloseDialogueUI();
            StaticManager.Instance.hasOrdered = true;
            StaticManager.Instance.influencerDialogueTracker++;

        }
    }
    public void CloseDialogueUI()
    {
        if (influencerCanvas != null) { influencerCanvas.SetActive(false); }
        if (generalUIOverlay != null) { generalUIOverlay.SetActive(true); }
    }

    public void WaitingDialogue()
    {
        // Toggle aprropriate UI, and select the appropriate button for control users
        if (nextButton != null) { nextButton.Select(); }
        if (simonImage != null) { simonImage.SetActive(true); }
        if (annaImage != null) { annaImage.SetActive(false); }
        if (influencerCanvas != null) { influencerCanvas.SetActive(true); }

        // Display a random line from the characters default dialogue, when user clicks next, then close the UI
        if (!clickedNext)
        {
            int i = Random.Range(0, DefaultDialogueArray.Length);
            if (dialogueText != null) { dialogueText.text = DefaultDialogueArray[i]; }
            clickedNext = !clickedNext;
        }
        else { CloseDialogueUI(); clickedNext = !clickedNext; }
    }


    public void ServingDialogue()
    {
        // Toggle aprropriate UI, and select the appropriate button for control users
        if (influencerCanvas != null) { influencerCanvas.SetActive(true); }

        // Display serving dialogue based on player's score.
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
    public void DetermineSpeaker()
    {
        // Start with Simon's image as he has the first line then switch back and forth between him and Anna.
        if (annaImage != null && simonImage != null)
        {
            if (simonsTurn)
            {
                simonImage.SetActive(true);
                annaImage.SetActive(false);
            }
            else if (!simonsTurn)
            {
                simonImage.SetActive(false);
                annaImage.SetActive(true);
            }
            simonsTurn = !simonsTurn;
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
            CloseDialogueUI();
            StaticManager.Instance.influencerDined = true;
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
        }
    }

    // Select the informal greeting option for the player, if they are using a control. 
    // Method referenced by Actions_FrontOfHouse
    public void SelectFirstButton()
    {
        if (nextButton != null)
        {
            nextButton.Select();
        } 
    }
}
