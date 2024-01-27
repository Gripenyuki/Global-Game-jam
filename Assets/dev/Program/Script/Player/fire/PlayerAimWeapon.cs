using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;

public class PlayerAimWeapon : MonoBehaviour
{
    private AudioSource AudioSource;

    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    public Transform buout;
    [SerializeField] private AudioClip GunShotSound;

    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        Aim();
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Aim()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, buout.position, transform.rotation);
        AudioSource.PlayOneShot(GunShotSound);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * bulletForce, ForceMode2D.Impulse);
    }
}
