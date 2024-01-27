using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private DialogueScript dialog;

    [SerializeField] private bool inRange;

    void Start()
    {
        dialog = GetComponent<DialogueScript>();
        dialog.enabled = false;
    }

    void Update()
    {
        if(inRange)
        {
            dialog.enabled = true;
        }
        else
        {
            dialog.enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            inRange = true;
        }
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            inRange = false;
        }
    }
}
