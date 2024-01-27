using System.Collections;
using UnityEngine;

public class Bulletboss : MonoBehaviour
{
    public float bulletSpeed = 5f;
    private Transform player;
    private Rigidbody2D rb;

    void Start()
    {
        player = GameObject.Find("Player").transform;
        if (player == null)
        {
            Debug.LogError("Player not found.");
        }

        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(BulletLive());
    }

    void Update()
    {
        if (player != null)
        {
            // Calculate the direction towards the player
            Vector2 direction = (player.position - transform.position).normalized;

            // Move the bullet towards the player
            rb.velocity = direction * bulletSpeed;
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
        else if (other.tag == "PlayerBull")
        {
            Destroy(gameObject);
        }
        else if (other.tag == "Player")
        {
            StartCoroutine(BulletEnemy(true, "Why don't you dodge this!!"));
        }
    }

    IEnumerator BulletEnemy(bool gameOverScreen, string deathCause)
    {
        rb.gravityScale = 0;
        rb.velocity = Vector3.zero;
        yield return new WaitForSeconds(0.8f);
        Manager.GameOverScreen.SetActive(gameOverScreen);
        Manager.DeathCause.text = deathCause;
        yield return new WaitForSeconds(0.1f);
        Manager.gameO(gameOverScreen);
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }

}
