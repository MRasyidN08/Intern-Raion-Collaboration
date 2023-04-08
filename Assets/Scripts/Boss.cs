using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject bulletPrefab;
    int bullet = 10;
    public float fireRate = 2f;
    private int health = 100;

    void Start()
    {
        InvokeRepeating("FireBullet", 0f, fireRate);
    }

    void FireBullet()
    {
        Instantiate(bulletPrefab, transform.GetChild(0).position, Quaternion.identity);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Bullet")
        {
            if (health <= 0)
            {
                Destroy(gameObject);
            }
            health -= bullet;
            Destroy(other.gameObject);
        }
    }
}
