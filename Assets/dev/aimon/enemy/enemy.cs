using System.Collections;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class enemy : MonoBehaviour
{
    public Transform[] patrolPoints;  // Use an array for multiple patrol points
    public float moveSpeed = 2f;
    private bool walk;
    private Rigidbody2D rb;
    bool live = true;
    private Animation eneA;
    private SpriteRenderer enemysr;
    public GameObject vfx;
    public Transform posboom;

    void Start()
    {
        StartCoroutine(Patrol());
        rb = GetComponent<Rigidbody2D>();
        eneA = GetComponent<Animation>();
        enemysr = GetComponent<SpriteRenderer>();
    }

    public void Getene()
    {
        live = false;
        Instantiate(vfx, posboom);
        Manager.Die(live, gameObject, eneA, 1f, this, enemysr);
    }

    IEnumerator Patrol()
    {
        while (true)  // Infinite loop for continuous patrol
        {
            foreach (Transform point in patrolPoints)
            {
                // Move towards the current patrol point
                while (transform.position != point.position)
                {
                    transform.position = Vector2.MoveTowards(transform.position, point.position, moveSpeed * Time.deltaTime);
                    yield return null;
                }

                // Wait for a short duration before moving to the next point
                yield return new WaitForSeconds(2f);  // Adjust the duration as needed
            }
        }
    }
    private void Update()
    {
        if (live == false)
        {
            rb.isKinematic = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.tag == "Player")
        {
            Manager.GameOverScreen.SetActive(true);
            Manager.DeathCause.text = "You got smashed to death by a lil cutie turtle";
        }
    }
}
