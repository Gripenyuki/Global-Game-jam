using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDiano : MonoBehaviour
{
    private CharacterController character;
    private Vector3 direction;

    public float gravity = 9.8f;
    public float jumpForce = 8f;
    private void Awake()
    {
        character = GetComponent<CharacterController>();
    }
    private void OnEnable()
    {
        direction = Vector3.zero;
    }
    private void Update()
    {
        direction += Vector3.down * gravity * Time.deltaTime;
        if (character.isGrounded)
        {
            direction = Vector3.down;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                direction = Vector3.up * jumpForce;
            }
        }
        character.Move(direction *Time.deltaTime);
    }
}
