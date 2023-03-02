using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Joshua Tyan

public class DropPotion : MonoBehaviour
{
    public GameObject potionPrefab;
    public Transform firePoint;

    //drops Potion
    public void Fire()
    {
        GameObject potion = Instantiate(potionPrefab, firePoint.position, firePoint.rotation);
    }
}
