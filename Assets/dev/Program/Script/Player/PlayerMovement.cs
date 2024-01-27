using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.WSA;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    public float speed = 8f;
    public float fly = 5f;
    private bool isGrounded;

    private AudioSource Source;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private AudioClip WalkSound;
    [SerializeField] private AudioClip JumpSound;

    void Start()
    {
        Source = GetComponent<AudioSource>();
    }
    
    // Update is called once per frame
    void Update()
    {   
        horizontal = Input.GetAxisRaw("Horizontal");
        
            if(Input.GetKeyDown(KeyCode.A))
            {
                Source.Play();
            }
            else if(Input.GetKeyUp(KeyCode.A))
            {
                Source.Stop();
            }
            if(Input.GetKeyDown(KeyCode.D))
            {
                Source.Play();
            }
            else if(Input.GetKeyUp(KeyCode.D))
            {
                Source.Stop();
            }        

        isGrounded = IsGrounded ();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Source.PlayOneShot(JumpSound);
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.velocity = new Vector2(rb.velocity.x, CalculateFlySpeed());
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
}
