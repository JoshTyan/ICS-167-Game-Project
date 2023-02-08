using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //different attack pattern
    //calls TakeDamage() if enemy in range
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireForce = 10f;

    public void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.Position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }
}