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
    [SerializeField] private string[] message;
    [SerializeField] private string PlayerName;
    [SerializeField] private string NPCName;
    private int currentIndex = 0;
    [SerializeField] private bool PlayerFirst;

    // Start is called before the first frame update
    void Start()
    {
       DialogueBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
     if(Input.GetKeyDown(KeyCode.E))
     {
         DialogueBox.SetActive(true);

         if(PlayerFirst)
         {
             NameBoxL.SetActive(true);
             NameBoxR.SetActive(false);
             PlayerFirst = !PlayerFirst;
         }
         else
         {
             NameBoxR.SetActive(true);
             NameBoxL.SetActive(false);
             PlayerFirst = !PlayerFirst;
         }

         if (currentIndex < message.Length)
         {
            TalkText.text = message[currentIndex];
            currentIndex++;
         }
         else
         {
            DialogueBox.SetActive(false);
            currentIndex = 0;
            if(message.Length % 2 == 0)
            {
                PlayerFirst = !PlayerFirst;
            }
         }
     }
    }
}
