using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossfine : MonoBehaviour
{
    public float speed = 3f;
    public GameObject bulletPrefab;
    public Transform firePoint;

    void Update()
    {
        // Rotate to face the player
        RotateTowardsPlayer();

        // Move forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Shoot
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void RotateTowardsPlayer()
    {
        GameObject player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            Vector3 direction = player.transform.position - transform.position;
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, Time.deltaTime * 5f);
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
