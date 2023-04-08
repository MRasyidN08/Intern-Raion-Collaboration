using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float fireRate = 2f;

    void Start()
    {
        InvokeRepeating("FireBullet", 0f, fireRate);
    }

    void FireBullet()
    {
        Instantiate(bulletPrefab, transform.GetChild(0).position, Quaternion.identity);
    }
}
