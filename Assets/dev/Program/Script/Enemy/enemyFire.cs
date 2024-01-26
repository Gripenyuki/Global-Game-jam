using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFire : MonoBehaviour
{
    public Transform firePoint1;
    public Transform firePoint2;
    public GameObject bulletPrefab;
    public float fireRate = 2f;
    private float nextFireTime = 0f;

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void Fire()
    {
        // Randomly choose between firePoint1 and firePoint2
        Transform selectedFirePoint = Random.Range(0f, 1f) > 0.5f ? firePoint1 : firePoint2;

        Instantiate(bulletPrefab, selectedFirePoint.position, selectedFirePoint.rotation);
    }
}
