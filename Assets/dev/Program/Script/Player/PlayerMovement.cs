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

    private AudioSource Source;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private AudioClip WalkSound;
    [SerializeField] private AudioClip JumpSound;
    [SerializeField] private AudioClip FlySound;
    [SerializeField] private AudioClip Landed;
    Animator playerA;

    void Start()
    {
        Source = GetComponent<AudioSource>();
        playerA = GetComponent<Animator>();
    }

    private void Reset()
    {
        playerA.SetBool("Run left", false);
        playerA.SetBool("Run right", false);
        playerA.SetBool("Id left", false);
        playerA.SetBool("Id right", false);
    }
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (isGround)
        {
            //Source.clip = WalkSound;
            if (Input.GetKeyDown(KeyCode.A))
            {
                Reset();
                playerA.SetBool("Run left", true);
                Source.Play();
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                Reset();
                playerA.SetBool("Run right", true);
                Source.Play();
            }
            else if (Input.GetKeyUp(KeyCode.A))
            {
                Reset();
                playerA.SetBool("Id left", true);
                Source.Stop();
            }
            else if (Input.GetKeyUp(KeyCode.D))
            {
                Reset();
                playerA.SetBool("Id right", true);
                Source.Stop();
            }
        }
        else if(Input.GetKeyUp(KeyCode.A))
        {
             Source.Stop();
        }
        else if(Input.GetKeyUp(KeyCode.D))
        {
             Source.Stop();
        }
        else if(!isGround)
        {
            Source.clip = null;
        }

        isGrounded = IsGrounded ();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(isGround)
            {
                Source.PlayOneShot(JumpSound);
                rb.bodyType = RigidbodyType2D.Kinematic;
                rb.velocity = new Vector2(rb.velocity.x, CalculateFlySpeed());
            }
            else
            {
                Source.PlayOneShot(FlySound);
                rb.bodyType = RigidbodyType2D.Kinematic;
                rb.velocity = new Vector2(rb.velocity.x, CalculateFlySpeed());
            }
        }
        else
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
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
        if(other.gameObject.CompareTag("G"))
        {
            Source.PlayOneShot(Landed);
            isGround = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("G"))
        {
            isGround = false;
        }
    }
}
