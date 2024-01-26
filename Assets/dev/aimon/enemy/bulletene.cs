using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletene : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(bulletlive());
    }
    IEnumerator bulletlive()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "G")
        {
            Destroy(gameObject);
        }
        if (other.tag == "Player")
        {

        }
    }
}
