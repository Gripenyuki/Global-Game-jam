using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletene : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "G")
        {
            Destroy(gameObject);
        }
    }
}
