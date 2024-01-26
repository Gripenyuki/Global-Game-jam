using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Transform patrolPoints;
    public Transform patrolPoints1;
    public float moveSpeed = 2f;
    void Start()
    {

    }

    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        transform.position = Vector2.MoveTowards(transform.position, patrolPoints.position, moveSpeed * Time.deltaTime);

    }
    IEnumerator StartCountdown()
    {
        yield return new WaitForSeconds(1f);
    }
}