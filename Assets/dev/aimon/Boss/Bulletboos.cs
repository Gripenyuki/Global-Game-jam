using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletboos : MonoBehaviour
{
    public float bulletSpeed = 5f;
    private Transform player;

    void Start()
    {
        player = GameObject.Find("Player").transform;
        if (player == null)
        {
            Debug.LogError("Player not found.");
        }
        StartCoroutine(bulletlive());
        rb = gameObject.GetComponent<Rigidbody2D>();
        bullB = GetComponent<Animator>();
    }

    void Update()
    {
        if (player != null)
        {
            // Calculate the direction towards the player
            Vector3 direction = (player.position - transform.position).normalized;

            // Move the bullet towards the player
            transform.Translate(direction * bulletSpeed * Time.deltaTime);
        }
    }

    Animator bullB;
    Rigidbody2D rb;
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
        else if (other.tag == "Player") 
        {
            StartCoroutine(bullene(true, "Why don't you dodge this!!"));
        }
        else if (other.tag == "PlayerBull")
        {
            Destroy(gameObject);
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
