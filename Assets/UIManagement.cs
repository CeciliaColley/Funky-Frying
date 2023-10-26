using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class UIManagement : MonoBehaviour
{
    public GameObject Hiya;
    public GameObject Welcome;
    public GameObject nextButton;
    public GameObject MainPanel;
    public Flash DoorFlash;
    public GameObject UI;
    public Text dialogueText;
    public GameObject RuggieroImage;
    public GameObject AnnaImage;
    public VideoPlayer videoPlayer;
    int dialogueTracker = 0;
    int speakerTracker = 0;

    public string[] DialogueArray = {
  /*0*/  "I'm good, thank you. Could I get a pasta pomodoro please?",
  /*1*/   "Um... Well, actually, we don't have pasta pomodoro on the menu today.",
  /*2*/   "It's ok. I'll have a pasta carbonara then.",
  /*3*/   "Uhhh... We actually don't have pasta on the me-",
  /*4*/   "Ooooooooooooo!",
  /*5*/   "I'm so excited! I've been looking forward to this all week, I even canceled my 4:00 o'clock meeting!",
  /*6*/   "...",
  /*7*/   "Uhhhhh... Ok... One pasta pomodoro coming right up!",
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
        System.Random randomNumber = new System.Random(); // Initialize random number
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
        if (!StaticManager.Instance.isServing)
        {
            if (StaticManager.Instance.dialogueTracker < DialogueArray.Length) // Ordering the pasta
            {
                if (StaticManager.Instance.dialogueTracker == 0 || StaticManager.Instance.dialogueTracker == 2 || StaticManager.Instance.dialogueTracker == 4 || StaticManager.Instance.dialogueTracker == 5)
                {
                    RuggieroImage.SetActive(true);
                    AnnaImage.SetActive(false);
                } else
                {
                    RuggieroImage.SetActive(false);
                    AnnaImage.SetActive(true);
                }
                dialogueText.text = DialogueArray[StaticManager.Instance.dialogueTracker];
                StaticManager.Instance.dialogueTracker = StaticManager.Instance.dialogueTracker + 1;
            }
            else if (StaticManager.Instance.dialogueTracker == DialogueArray.Length) //Closing the UI
            {
                MainPanel.SetActive(false);
                DoorFlash.isFlashing = true;
                StaticManager.Instance.dialogueTracker = StaticManager.Instance.dialogueTracker + 1;
                StaticManager.Instance.hasOrdered = true;
            }
            else if (StaticManager.Instance.dialogueTracker == DialogueArray.Length + 1) //Default Dialogue
            {
                RuggieroImage.SetActive(true);
                AnnaImage.SetActive(false);
                Hiya.SetActive(false);
                Welcome.SetActive(false);
                int i = Random.Range(0, DefaultDialogueArray.Length);
                MainPanel.SetActive(true);
                dialogueText.text = DefaultDialogueArray[i];
                StaticManager.Instance.dialogueTracker = 7;
            }
        }
        else
        {
            if ( StaticManager.Instance.playerScore == 100)
            {
                MainPanel.SetActive(true);
                if (speakerTracker == 0)
                {
                    RuggieroImage.SetActive(true);
                    AnnaImage.SetActive(false);
                } else if (speakerTracker == 1)
                {
                    RuggieroImage.SetActive(false);
                    AnnaImage.SetActive(true);
                }
                Hiya.SetActive(false);
                Welcome.SetActive(false);
                if (dialogueTracker == perfectDialogue.Length)
                {
                    SceneManager.LoadScene("Credits");
                }
                else dialogueText.text = perfectDialogue[dialogueTracker];
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
            else if (StaticManager.Instance.playerScore >= 90 && StaticManager.Instance.playerScore <= 99)
            {
                MainPanel.SetActive(true);
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
                Hiya.SetActive(false);
                Welcome.SetActive(false);
                if (dialogueTracker == greatDialogue.Length)
                {
                    SceneManager.LoadScene("Credits");
                }
                else dialogueText.text = greatDialogue[dialogueTracker];
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
            else if (StaticManager.Instance.playerScore >= 80 && StaticManager.Instance.playerScore <= 89)
            {
                MainPanel.SetActive(true);
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
                Hiya.SetActive(false);
                Welcome.SetActive(false);
                if (dialogueTracker == goodDialogue.Length)
                {
                    SceneManager.LoadScene("Credits");
                }
                else dialogueText.text = goodDialogue[dialogueTracker];
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
            else if (StaticManager.Instance.playerScore >= 70 && StaticManager.Instance.playerScore <= 79)
            {
                MainPanel.SetActive(true);
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
                Hiya.SetActive(false);
                Welcome.SetActive(false);
                if (dialogueTracker == okDialogue.Length)
                {
                    SceneManager.LoadScene("Credits");
                } else dialogueText.text = okDialogue[dialogueTracker];
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
        }
    }
}
