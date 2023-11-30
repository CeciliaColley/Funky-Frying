using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InfluencerUIManager : MonoBehaviour
{
    [SerializeField] private GameObject UI;
    [SerializeField] private Text dialogueText;
    [SerializeField] public GameObject SimonImage;
    [SerializeField] private GameObject AnnaImage;
    [SerializeField] public GameObject nextButton;
    [SerializeField] private int speakerTracker = 0;
    [SerializeField] private int dialogueTracker = 0;


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

    // Start is called before the first frame update
    void Start()
    {
        UI.SetActive(false);
        
    }


    public void displayDialogue()
    {
        UI.SetActive(true);
        if (!StaticManager.Instance.isServing)
        {
            if (StaticManager.Instance.influencerDialogueTracker <= DialogueArray.Length) { orderDialogue(); }
            else if (StaticManager.Instance.influencerDialogueTracker == DialogueArray.Length + 1) { defaultDialogue(); }
        }
        else
        {
            servingDialogue();
        }
    }

    public void orderDialogue()
    {
        determineSpeaker();
        if (StaticManager.Instance.influencerDialogueTracker < DialogueArray.Length)
        {
            if (StaticManager.Instance.influencerDialogueTracker == 6 || StaticManager.Instance.influencerDialogueTracker == 8)
            {
                dialogueText.fontSize = 32;
            }
            else { dialogueText.fontSize = 40; }
            dialogueText.text = DialogueArray[StaticManager.Instance.influencerDialogueTracker];
            StaticManager.Instance.influencerDialogueTracker++;
        }
        else
        {
            UI.SetActive(false);
            StaticManager.Instance.influencerHasOrdered = true;
            StaticManager.Instance.hasOrdered = true;
            StaticManager.Instance.influencerDialogueTracker++;

        }
    }


    public void determineSpeaker()
    {
        if (speakerTracker == 0)
        {
            SimonImage.SetActive(true);
            AnnaImage.SetActive(false);
            speakerTracker = 1;
        }
        else if (speakerTracker == 1)
        {
            SimonImage.SetActive(false);
            AnnaImage.SetActive(true);
            speakerTracker = 0;
        }
    }

    public void defaultDialogue()
    {
        SimonImage.SetActive(true);
        AnnaImage.SetActive(false);
        int i = Random.Range(0, DefaultDialogueArray.Length);
        UI.SetActive(true);
        dialogueText.text = DefaultDialogueArray[i];
        StaticManager.Instance.influencerDialogueTracker = DialogueArray.Length;
    }

    public void followConversation(string[] Dialogue)
    {
        if (dialogueTracker < Dialogue.Length)
        {
            dialogueText.text = Dialogue[dialogueTracker];
        }
        else
        {
            SceneManager.LoadScene("Credits");
        }

        if (speakerTracker == 0)
        {
            speakerTracker = 1;
        }
        else if (speakerTracker == 1)
        {
            speakerTracker = 0;
        }
        dialogueTracker++;
    }


    public void servingDialogue()
    {
        UI.SetActive(true);
        if (StaticManager.Instance.playerScore == 100)
        {
            determineSpeaker();
            followConversation(perfectDialogue);
        }
        else if (StaticManager.Instance.playerScore >= 90 && StaticManager.Instance.playerScore <= 99)
        {
            determineSpeaker();
            followConversation(greatDialogue);
        }
        else if (StaticManager.Instance.playerScore >= 80 && StaticManager.Instance.playerScore <= 89)
        {
            determineSpeaker();
            followConversation(goodDialogue);
        }
        else if (StaticManager.Instance.playerScore >= 70 && StaticManager.Instance.playerScore <= 79)
        {
            determineSpeaker();
            followConversation(okDialogue);
        }
    }
}
