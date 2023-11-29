using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class UIManagement : MonoBehaviour
{
    [SerializeField] private GameObject Hiya;
    [SerializeField] private GameObject Welcome;
    [SerializeField] public GameObject nextButton;
    [SerializeField] public GameObject MainPanel;
    [SerializeField] private GameObject Lawyer;
    [SerializeField] private Flash DoorFlash;
    [SerializeField] private GameObject UI;
    [SerializeField] private Text dialogueText;
    [SerializeField] public GameObject RuggieroImage;
    [SerializeField] private GameObject AnnaImage;
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private int dialogueTracker = 0;
    [SerializeField] private int speakerTracker = 0;

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
        //TODO: TP1 - Unused method/variable: I thought I needed to do that every time I used a random number!
        MainPanel.SetActive(false);
        

    }
    public void ChooseOption()
    {
        Destroy(Hiya);
        Destroy(Welcome);
        nextButton.SetActive(true);
        DisplayDialogue();
    }

    public void DisplayDialogue()
    {
        //TODO: TP2 - Fix - Clean code
        if (!StaticManager.Instance.isServing)
        {
            if (StaticManager.Instance.dialogueTracker < DialogueArray.Length) orderingDialogue();
            else if (StaticManager.Instance.dialogueTracker == DialogueArray.Length + 1) { defaultDialogue(); }
        }
        else
        {
            servingDialogue();
        }
    }

    public void orderingDialogue()
    {
        if (StaticManager.Instance.dialogueTracker == 0 || StaticManager.Instance.dialogueTracker == 2 || StaticManager.Instance.dialogueTracker == 4 || StaticManager.Instance.dialogueTracker == 5)
        {
            RuggieroImage.SetActive(true);
            AnnaImage.SetActive(false);
        }
        else
        {
            RuggieroImage.SetActive(false);
            AnnaImage.SetActive(true);
        }

        if (StaticManager.Instance.dialogueTracker < DialogueArray.Length - 1)
        {
            StaticManager.Instance.dialogueTracker++;
            dialogueText.text = DialogueArray[StaticManager.Instance.dialogueTracker];
        }
        else
        {
            MainPanel.SetActive(false);
            DoorFlash.isFlashing = true;
            StaticManager.Instance.hasOrdered = true;
            StaticManager.Instance.dialogueTracker++;
        }
    }

    public void defaultDialogue()
    {
        RuggieroImage.SetActive(true);
        AnnaImage.SetActive(false);
        if (Hiya != null) { Hiya.SetActive(false); }
        if (Welcome != null) { Welcome.SetActive(false); }
        int i = Random.Range(0, DefaultDialogueArray.Length);
        MainPanel.SetActive(true);
        dialogueText.text = DefaultDialogueArray[i];
        StaticManager.Instance.dialogueTracker = DialogueArray.Length + 1;
    }

    public void servingDialogue()
    {
        Hiya.SetActive(false);
        Welcome.SetActive(false);
        MainPanel.SetActive(true);
        if (StaticManager.Instance.lawyerIsDining == true)
        {
            if (StaticManager.Instance.playerScore == 100)
            {
                determineSpeaker();
                followConversation(perfectDialogue);
                retireCustomer(perfectDialogue, Lawyer);
            }
            else if (StaticManager.Instance.playerScore >= 90 && StaticManager.Instance.playerScore <= 99)
            {
                MainPanel.SetActive(true);
                determineSpeaker();
                followConversation(greatDialogue);
                retireCustomer(greatDialogue, Lawyer);

            }
            else if (StaticManager.Instance.playerScore >= 80 && StaticManager.Instance.playerScore <= 89)
            {
                MainPanel.SetActive(true);
                determineSpeaker();
                followConversation(goodDialogue);
                retireCustomer(goodDialogue, Lawyer);
            }
            else if (StaticManager.Instance.playerScore >= 70 && StaticManager.Instance.playerScore <= 79)
            {
                MainPanel.SetActive(true);
                determineSpeaker();
                followConversation(okDialogue);
                retireCustomer(okDialogue, Lawyer);
            }
        } else { Debug.Log("Cannot display dialogue because lawyer is null"); }
    }

    public void determineSpeaker()
    {
        if (speakerTracker == 0)
        {
            RuggieroImage.SetActive(true);
            AnnaImage.SetActive(false);
        }
        else if (speakerTracker == 1)
        {
            RuggieroImage.SetActive(false);
            AnnaImage.SetActive(true);
        }
    }

    public void followConversation(string[] Dialogue)
    {
        if (dialogueTracker < Dialogue.Length - 1)
        {
            dialogueText.text = Dialogue[dialogueTracker];
        }
        else
        {
            MainPanel.SetActive(false);
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

    public void retireCustomer(string[] Dialogue, GameObject Customer)
    {
        if (dialogueTracker == Dialogue.Length)
        {
            StaticManager.Instance.lawyerIsDining = false;
            Lawyer = GameObject.Find("Lawyer(Clone)");
            Destroy(Lawyer);
            StaticManager.Instance.isServing = false;
        }
    }
}