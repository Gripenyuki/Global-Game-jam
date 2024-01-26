using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InRangeCheck : MonoBehaviour
{
    public static bool inRange;

    void Start()
    {
        inRange = false;
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
