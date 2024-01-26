using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private DialogueScript dialog;
    private InRangeCheck InRangeScript;

    [SerializeField] private GameObject detectionRange;
    [SerializeField] private bool inRange;

    void Start()
    {
        dialog = GetComponent<DialogueScript>();
        InRangeScript = FindObjectOfType<InRangeCheck>();
        dialog.enabled = false;
    }

    void Update()
    {
        inRange = InRangeCheck.inRange; 

        if(inRange)
        {
            dialog.enabled = true;
        }
        else
        {
            dialog.enabled = false;
        }
    }
}
