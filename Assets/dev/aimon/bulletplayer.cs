using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletplayer : MonoBehaviour
{
    private void Start()
    {
        GameObject foundObject = GameObject.Find("ObjectName");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Check to see if the tag on the collider is equal to Enemy
        if (other.CompareTag("Enemy"))
        {
            enemy ene = other.GetComponent<enemy>();
            ene.Getene();
        }
        else if (other.tag == "G")
        {
            Destroy(gameObject);
        }
    }

   
}
