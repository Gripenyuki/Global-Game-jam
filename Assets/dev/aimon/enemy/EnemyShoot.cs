using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public Transform target;  // The player or target the enemy will shoot at
    public GameObject projectilePrefab;  // The projectile the enemy will shoot
    private float shootingInterval = 1f;  // Time between shots
    private float projectileSpeed = 5f;  // Speed of the projectile
    private float detectionRange = 10f;   // Range within which the enemy can detect the player
    private bool live;
    private SpriteRenderer enemysr;
    private Animation eneA;
    private AudioSource Source;
    [SerializeField] private AudioClip ShotSound;
    void Start()
    {
        StartCoroutine(ShootRoutine());
        enemysr = gameObject.GetComponent<SpriteRenderer>();
        Source = GetComponent<AudioSource>();
    }
    public void Getene1()
    {
        live = false;
        Manager.Die(live, gameObject, eneA, 0.5f, this, enemysr);
    }
    IEnumerator ShootRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootingInterval);

            if (IsPlayerInDetectionRange())
            {
                if(live = true)
                {
                    Shoot();
                }
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
            Source.PlayOneShot(ShotSound);
            Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
            projectileRb.velocity = direction * projectileSpeed;
        }
    }
}
