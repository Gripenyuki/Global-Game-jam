using System.Collections;
using UnityEngine;

public class Bossfine : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float bulletSpeed = 5f;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;

    void Start()
    {
        StartCoroutine(BossBulletPattern());
    }


    IEnumerator BossBulletPattern()
    {
        while (true)
        {
            // Simple bullet pattern
            for (int i = 0; i < 5; i++)
            {
                ShootBullet(i * 20f);
            }

            yield return new WaitForSeconds(1f);
        }
    }

    void ShootBullet(float angle)
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.Euler(0f, 0f, angle));
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = bullet.transform.right * bulletSpeed;
    }
}
