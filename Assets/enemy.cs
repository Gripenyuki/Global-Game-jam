using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float moveSpeed = 2f;
    private int currentPoint = 0;

    void Start()
    {
        if (patrolPoints.Length > 0)
        {0
            transform.position = patrolPoints[0].position;
        }
        else
        {
            Debug.LogError("No patrol points assigned to the enemy.");
        }
    }

    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        if (patrolPoints.Length > 0)
        {
            // Move towards the current patrol point
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPoint].position, moveSpeed * Time.deltaTime);

            // Check if the enemy has reached the current patrol point
            if (Vector2.Distance(transform.position, patrolPoints[currentPoint].position) < 0.1f)
            {
                // Move to the next patrol point
                currentPoint = (currentPoint + 1) % patrolPoints.Length;
            }
        }
    }
}