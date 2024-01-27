using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bulletboss : MonoBehaviour
{
    public float bulletSpeed = 5f;
    private Transform player;
    private NavMeshAgent navMeshAgent;
    private Rigidbody2D rb;
    private Animator bullAnimator;

    void Start()
    {
        GameObject player = GameObject.Find("Player");
        if (player == null)
        {
            Debug.LogError("Player not found.");
        }

        rb = GetComponent<Rigidbody2D>();
        bullAnimator = GetComponent<Animator>();

        navMeshAgent = gameObject.AddComponent<NavMeshAgent>();
        navMeshAgent.speed = bulletSpeed;
        navMeshAgent.autoBraking = false;

        StartCoroutine(BulletLive());
    }

    void Update()
    {
        if (player != null)
        {
            // Set the destination of the NavMeshAgent to the player's position
            navMeshAgent.SetDestination(player.position);
        }
    }

    IEnumerator BulletLive()
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
            StartCoroutine(BulletEnemy(true, "Why don't you dodge this!!"));
        }
        else if (other.tag == "PlayerBull")
        {
            Destroy(gameObject);
        }
    }

    IEnumerator BulletEnemy(bool gameOverScreen, string deathCause)
    {
        rb.gravityScale = 0;
        rb.velocity = Vector3.zero;
        bullAnimator.Play("hitplay");
        yield return new WaitForSeconds(0.8f);
        Manager.GameOverScreen.SetActive(gameOverScreen);
        Manager.DeathCause.text = deathCause;
        yield return new WaitForSeconds(0.1f);
        Manager.gameO(gameOverScreen);
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}

