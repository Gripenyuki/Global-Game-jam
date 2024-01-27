using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueScript : MonoBehaviour
{
    [SerializeField] private GameObject DialogueBox;
    [SerializeField] private GameObject NameBoxR;
    [SerializeField] private GameObject NameBoxL;
    [SerializeField] private TextMeshProUGUI TalkText;
    [SerializeField] private TextMeshProUGUI PlayerTxt;
    [SerializeField] private TextMeshProUGUI NPCText;
    public string[] message;
    [SerializeField] private string PlayerName;
    [SerializeField] private string NPCName;
    private int currentIndex = 0;
    private int previousIndex;
    [SerializeField] private bool NPCFirst;
    private bool eKeyPressedLastFrame =false;
    [SerializeField] private AudioClip[] Conversation;
    private AudioSource conver;

    // Start is called before the first frame update
    void Start()
    {
            DialogueBox.SetActive(false);
            PlayerTxt.text = PlayerName;
            NPCText.text = NPCName; 
            conver = GetComponent<AudioSource>();
    }

    void Update()
    {
        bool eKeyPressed = Input.GetKeyDown(KeyCode.E);

        if (eKeyPressed && !eKeyPressedLastFrame)
        {
            DialogueBox.SetActive(true);

            if (currentIndex < message.Length)
            {
                TalkText.text = message[currentIndex];
                previousIndex = currentIndex;
                currentIndex++;
            }
            else
            {
                DialogueBox.SetActive(false);
                currentIndex = 0;
            }
            
            if(currentIndex < Conversation.Length)
            {
                conver.PlayOneShot(Conversation[currentIndex]);
            }

            if(currentIndex != previousIndex)
            {
               NPCFirst = !NPCFirst;
            }

            if(!DialogueBox.gameObject.activeSelf)
            {
                if (message.Length % 2 == 0)
                {
                    NPCFirst = !NPCFirst;
                }
            }
        }

        if (NPCFirst)
        {
            NameBoxL.SetActive(true);
            NameBoxR.SetActive(false);
        }
        else
        {
            NameBoxR.SetActive(true);
            NameBoxL.SetActive(false);
        }

        eKeyPressedLastFrame = eKeyPressed;
    }
}
