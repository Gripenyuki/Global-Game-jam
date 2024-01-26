using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform[] patrolPoints;  // Use an array for multiple patrol points
    public float moveSpeed = 2f;
    private bool walk;

    void Start()
    {
        StartCoroutine(Patrol());
    }

    void Update()
    {
        // Any additional update logic can be added here
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
}
