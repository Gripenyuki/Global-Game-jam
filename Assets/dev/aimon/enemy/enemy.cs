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
    private Animator eneA;
    private SpriteRenderer enemysr;
    public GameObject vfx;
    public Transform posboom;
    private AudioSource Dead;
    [SerializeField] private AudioClip DS;
    [SerializeField] private AudioClip MD;
    GameObject AudioSus;

    void Start()
    {
        StartCoroutine(Patrol());
        rb = GetComponent<Rigidbody2D>();
        eneA = GetComponent<Animator>();
        enemysr = GetComponent<SpriteRenderer>();
        AudioSus = GameObject.Find("DeadSoundSource");
        Dead = AudioSus.GetComponent<AudioSource>();
    }

    public void Getene()
    {
        live = false;
        Instantiate(vfx, posboom);
        Dead.PlayOneShot(MD);
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

                enemysr.flipX = !enemysr.flipX;

                // Wait for a short duration before moving to the next point
                yield return new WaitForSeconds(2f);  // Adjust the duration as needed
            }
        }
    }
}
