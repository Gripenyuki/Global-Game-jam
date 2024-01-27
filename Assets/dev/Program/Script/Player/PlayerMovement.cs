using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.WSA;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    public float speed = 8f;
    public float fly = 5f;
    private bool isGrounded;
    private bool isGround;
    private Animator playerA;
    private AudioSource Source;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private AudioClip WalkSound;
    [SerializeField] private AudioClip JumpSound;
    [SerializeField] private AudioClip FlySound;
    [SerializeField] private AudioClip Landed;
    private SpriteRenderer spriteRenderer;
    bool hasFlipped = false;
    GameObject gun;
    GameObject gun1;
    void Start()
    {
        gun = GameObject.Find("Gun");
        gun1 = GameObject.Find("Gun (1)");
        Source = GetComponent<AudioSource>();
        playerA = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Reset()
    {
        playerA.SetBool("Run left", false);
        playerA.SetBool("Run right", false);
        playerA.SetBool("Id left", false);
        playerA.SetBool("Id right", false);
        playerA.SetBool("jump right", false);
        playerA.SetBool("Jd", false);
    }
    void Update()
    {
        Debug.Log(hasFlipped);
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyUp(KeyCode.A))
        {
            gun.SetActive(true);
            gun1.SetActive(false);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            gun.SetActive(false);
            gun1.SetActive(true);
        }
        if (isGround)
        {
            // Get the current speed of the character
            float speed = Mathf.Abs(rb.velocity.x);

            //Source.clip = WalkSound;
            Reset();
            // Check if the character is moving0
            if (speed > 0.1f)
            {
                Debug.Log("????");
                // Choose the appropriate animation based on the direction
                if (rb.velocity.x < 0)
                {
                    if (hasFlipped)
                    {
                        FlipSprite();
                        hasFlipped = false; // Reset the flag
                    }
                    playerA.SetBool("Run left", true);
                }
                else
                {
                    if (!hasFlipped)
                    {
                        FlipSprite();
                        hasFlipped = true; // Reset the flag
                    }
                    playerA.SetBool("Run left", true);
                }

                Source.Play();
            }
            else
            {
                // No movement, reset to idle
                Reset();
                playerA.SetBool("Id left", true);  // Or use "Id right" based on your setup
                Source.Stop();
            }
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            Source.Stop();
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            
            Source.Stop();
        }
        else if (!isGround)
        {
            Source.clip = null;
        }

        isGrounded = IsGrounded();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGround)
            {
                Source.PlayOneShot(JumpSound);
                rb.bodyType = RigidbodyType2D.Kinematic;
                rb.velocity = new Vector2(rb.velocity.x, CalculateFlySpeed());
                Reset();
                playerA.SetBool("jump right", true);
            }
            else
            {
                Source.PlayOneShot(FlySound);
                rb.bodyType = RigidbodyType2D.Kinematic;
                rb.velocity = new Vector2(rb.velocity.x, CalculateFlySpeed());
                Reset();
                playerA.SetBool("fly left", true);
            }
        }
        else
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }
    private void FlipSprite()
    {
        // Reverse the current horizontal scale
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    private float CalculateFlySpeed()
    {
        return fly;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("G"))
        {
            Reset();
            playerA.SetBool("Jd", true);
            Source.PlayOneShot(Landed);
            isGround = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("G"))
        {
            isGround = false;
        }
    }
}
