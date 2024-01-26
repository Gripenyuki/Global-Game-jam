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

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    // Update is called once per frame
    void Update()
    {   
        horizontal = Input.GetAxisRaw("Horizontal");
        isGrounded = IsGrounded ();

        if (Input.GetKeyDown(KeyCode.Space))
        {
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
