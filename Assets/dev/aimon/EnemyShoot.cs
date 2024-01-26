using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public Transform target;  // The player or target the enemy will shoot at
    public GameObject projectilePrefab;  // The projectile the enemy will shoot
    private float shootingInterval = 0.1f;  // Time between shots
    private float projectileSpeed = 5f;  // Speed of the projectile
    private float detectionRange = 10f;   // Range within which the enemy can detect the player

    void Start()
    {
        StartCoroutine(ShootRoutine());
    }

    IEnumerator ShootRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootingInterval);

            if (IsPlayerInDetectionRange())
            {
                Shoot();
            }
        }
    }

    bool IsPlayerInDetectionRange()
    {
        if (target != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, target.position);
            return distanceToPlayer <= detectionRange;
        }

        return false;
    }

    void Shoot()
    {
        if (target != null && projectilePrefab != null)
        {
            Vector2 direction = (target.position - transform.position).normalized;
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
            projectileRb.velocity = direction * projectileSpeed;
        }
    }
}
