using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletene : MonoBehaviour
{
    Animator bullB;
    Rigidbody2D rb;
    private void Start()
    {
        StartCoroutine(bulletlive());
        rb = gameObject.GetComponent<Rigidbody2D>();
        bullB = GetComponent<Animator>();
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
            StartCoroutine(bullene(false, " "));
        }
        if (other.tag == "Player")
        {
            StartCoroutine(bullene(true, "Why don't you dodge this!!"));
        }
    }
    IEnumerator bullene(bool GOS, string DC)
    {
        rb.gravityScale = 0;
        rb.velocity = Vector3.zero;
        bullB.Play("hitplay");
        yield return new WaitForSeconds(0.8f);
        Manager.GameOverScreen.SetActive(GOS);
        Manager.DeathCause.text = DC;
        yield return new WaitForSeconds(0.1f);
        Manager.gameO(GOS);
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
