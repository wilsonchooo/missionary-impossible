﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("x"))
        {
            shoot();
        }

    }
    void shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
