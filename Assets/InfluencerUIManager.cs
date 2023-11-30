using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfluencerUIManager : MonoBehaviour
{
    [SerializeField] private GameObject UI;
    [SerializeField] private Text dialogueText;
    [SerializeField] public GameObject SimonImage;
    [SerializeField] private GameObject AnnaImage;
    [SerializeField] public GameObject nextButton;
    [SerializeField] private int speakerTracker = 0;

    public string[] DialogueArray = {
        "Well howdy there!",
        "Hi! I'm Anna and I'll be your server today.",
        "Hi Anna. I'd introduce myself, but I'm pretty sure you already know who I am.",
        "I uh-",
        "5 million subscribers on imbetterthanu.com! Yeah, baby, LET'S GOOOOOOOOO",
        "Oh, uh",
        "Alright, listen up: I want a meticulously handcrafted, gluten-free, organic, non-GMO, artisanal kale salad, but only if the kale has been serenaded by a choir of organic, free-range chickens for at least 30 minutes.",
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
            else { Debug.Log("Neither becasue dialogue tracker:" + StaticManager.Instance.influencerDialogueTracker);  }
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
            } else { dialogueText.fontSize = 40; }
            dialogueText.text = DialogueArray[StaticManager.Instance.influencerDialogueTracker];
            StaticManager.Instance.influencerDialogueTracker++;
        }
        else
        {
            UI.SetActive(false);
            StaticManager.Instance.influencerHasOrdered = true;
            StaticManager.Instance.influencerDialogueTracker++;
            StaticManager.Instance.hasOrdered = true;
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
        Debug.Log("Default Dialogue happening");
        SimonImage.SetActive(true);
        AnnaImage.SetActive(false);
        int i = Random.Range(0, DefaultDialogueArray.Length);
        UI.SetActive(true);
        dialogueText.text = DefaultDialogueArray[i];
        StaticManager.Instance.influencerDialogueTracker = DialogueArray.Length;
    }

    public void servingDialogue()
    {
        UI.SetActive(true);
    }
}
